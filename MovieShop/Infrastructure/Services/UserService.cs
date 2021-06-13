using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using System.Net;
using MaxMind.GeoIP2.Exceptions;
using HttpException = ApplicationCore.Exceptions.HttpException;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMovieService _movieService;

        public UserService(IUserRepository userRepository, ICurrentUserService currentUserService, 
                                 IPurchaseRepository purchaseRepository, IMovieService movieService) 
        {
            _userRepository = userRepository;
            _currentUserService = currentUserService;
            _purchaseRepository = purchaseRepository;
            _movieService = movieService;
        }
        public async Task PurchaseMovie(PurchaseMovieRequestModel purchaseMovieRequest)
        {
            if (_currentUserService.UserId != purchaseMovieRequest.UserId)
                throw new HttpException(HttpStatusCode.Unauthorized, "You are not Authorized to purchase");

            purchaseMovieRequest.UserId = _currentUserService.UserId;
            // See if Movie is already purchased.
            if (await IsMoviePurchased(purchaseMovieRequest))
                throw new ConflictException("Movie already Purchased");
            // Get Movie Price from Movie Table
            var movie = await _movieService.GetMovieDetailsById(purchaseMovieRequest.MovieId);
            

            var purchase = new Purchase
            {
                UserId = _currentUserService.UserId,
                PurchaseNumber = (Guid)purchaseMovieRequest.PurchaseNumber,
                TotalPrice = (decimal)movie.Price,
                PurchaseDateTime = (DateTime)purchaseMovieRequest.PurchaseDateTime,
                MovieId = purchaseMovieRequest.MovieId
            };

            await _purchaseRepository.Add(purchase);
        }

        public async Task<bool> IsMoviePurchased(PurchaseMovieRequestModel purchaseRequest)
        {
            return await _purchaseRepository.GetExists(p =>
                p.UserId == purchaseRequest.UserId && p.MovieId == purchaseRequest.MovieId);
        }
        public async Task<List<MovieCardResponseModel>> GetPurchasedMovies(int id)
        {
            //var user = await _userRepository.GetById(id);
            //if(user.Id ! == _currentUserService.UserId)
            //{
            //    return null;
            //}

            var purchasedMovies = await _purchaseRepository.GetUserPurchases(id);

            var purchasesMovieCardList = new List<MovieCardResponseModel>();
            foreach (var purchase in purchasedMovies)
            {
                purchasesMovieCardList.Add(new MovieCardResponseModel
                {
                    Id = purchase.Movie.Id,
                    Title = purchase.Movie.Title,
                    PosterUrl = purchase.Movie.PosterUrl,
                    ReleaseDate = purchase.Movie.ReleaseDate.GetValueOrDefault(),

                });

            }

            return purchasesMovieCardList;

        }
        public async Task EditUser(UserProfileRequestModel userProfileRequestModel)
        {
            //var salt = CreateSalt();
            //var hashedPassword = CreateHashedPassword(userProfileRequestModel.Password, salt);

            var currentUser = await _userRepository.GetUserbyEmail(_currentUserService.Email);

            var inputUser = new User
            {
                FirstName = userProfileRequestModel.FirstName,
                LastName = userProfileRequestModel.LastName,
                Email = userProfileRequestModel.Email,
                DateOfBirth = userProfileRequestModel.DateOfBirth,
                //Salt = salt,
                //HashedPassword = hashedPassword
            };

            currentUser.FirstName = inputUser.FirstName;
            currentUser.LastName = inputUser.LastName;
            currentUser.Email = inputUser.Email;
            currentUser.DateOfBirth = inputUser.DateOfBirth;

            await _userRepository.Update(currentUser);
             
        }

        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel userRegisterRequestModel)
        {
            // first we need to check the email does not exists in our database

            var dbUser = await _userRepository.GetUserbyEmail(userRegisterRequestModel.Email);

            if (dbUser != null)
                // email exists in db
                throw new ConflictException("User already exists, please try to login");

            // generate a unique Salt
            var salt = CreateSalt();

            // hash the password with userRegisterRequestModel.Password + salt from above step
            var hashedPassword = CreateHashedPassword(userRegisterRequestModel.Password, salt);

            // call the user repository to save the user Info

            var user = new User
            {
                FirstName = userRegisterRequestModel.FirstName,
                LastName = userRegisterRequestModel.LastName,
                Email = userRegisterRequestModel.Email,
                DateOfBirth = userRegisterRequestModel.DateOfBirth,
                Salt = salt,
                HashedPassword = hashedPassword
            };

            var createdUser = await _userRepository.Add(user);

            // convert the returned user entity to UserRegisterResponseModel

            var response = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName,
                Email = createdUser.Email
            };

            return response;
        }

        public async Task<UserLoginResponseModel> Login(string email, string password)
        {
            // go to database and get the user info -- row by email
            var user = await _userRepository.GetUserbyEmail(email);

            if (user == null)
            {
                // return null
                return null;
            }

            // get the password from UI and salt from above step from database and call CreateHashedPassword method

            var hashedPassword = CreateHashedPassword(password, user.Salt);

            if (hashedPassword == user.HashedPassword)
            {
                // user entered correct password

                var loginResponseModel = new UserLoginResponseModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
                return loginResponseModel;
            }

            return null;
        }

        private string CreateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }
        private string CreateHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }

    }
}

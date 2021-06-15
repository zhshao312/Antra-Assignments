using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel userRegisterRequestModel);

        Task<UserLoginResponseModel> Login(string email, string password);

        Task EditUser(UserProfileRequestModel userProfileRequestModel);
        Task<List<MovieCardResponseModel>> GetPurchasedMovies(int id);
        Task PurchaseMovie(PurchaseMovieRequestModel purchaseMovieRequest);
        Task<UserProfileResponseModel> GetUserDetails(int id);

        //delete
        //editUser
        //change password
        //purchase movie
        //favorite movie
        //add review
        //get all purchase movie
        //get all favorite movie
        //edit Review
        //remove favorite
        //get user details
    }
}

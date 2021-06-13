using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ICurrentUserService _currentUserSerivce;
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;



        public UserController(ICurrentUserService currentUserSerivce, IUserService userService, IMovieService movieService)
        {
            _currentUserSerivce = currentUserSerivce;
            _userService = userService;
            _movieService = movieService;
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserPurchasesMovies()
        {
            var userId = _currentUserSerivce.UserId;
            //check whether user is loged in and 
            //if the user is not loged in redirect to login page
            //make a request to the database and get info from Purchase Table
            //select * from purchase where userid = @getfromcookie
            var purchaseMovies = await _userService.GetPurchasedMovies(userId);
            return View(purchaseMovies);
        }


        [HttpGet]
        public async Task<IActionResult> PurchaseMovie(int id)
        {
            ViewBag.movie  = await _movieService.GetMovieDetailsById(id);
            
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PurchasesMovieAction(PurchaseMovieRequestModel purchase)
        {
            //get userId from CurrentUser and create a row in Purchase table
            await _userService.PurchaseMovie(purchase);
            return LocalRedirect("~/");
        }
        [HttpGet]
        public IActionResult ViewProfile()
        {
            return View();
        }

        public IActionResult EditProfile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserProfileRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await _userService.EditUser(model);
            }
            return LocalRedirect("~/Account/Login");
        }

        public LocalRedirectResult RedirectHome()
        {
            return LocalRedirect("~/Home/Index");
        }

        public LocalRedirectResult RedirectEdit()
        {
            return LocalRedirect("~/User/EditProfile");
        }


    }

}

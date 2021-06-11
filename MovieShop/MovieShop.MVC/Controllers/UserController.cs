using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ICurrentUserService _currentUserSerivce;
        
        public UserController(CurrentUserService currentUserSerivce)
        {
            _currentUserSerivce = currentUserSerivce;
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
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PurchasesMovies()
        {
            //get userId from CurrentUser and create a row in Purchase table
            return View();
        }

        public async Task<IActionResult> ViewProfile()
        {
            //get userId from CurrentUser and create a row in Purchase table
            return View();
        }

        public async Task<IActionResult> EditProfile()
        {
            //get userId from CurrentUser and create a row in Purchase table
            return View();
        }

    }

}

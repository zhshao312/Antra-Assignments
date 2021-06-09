
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class AccountController : Controller
    {
        //localhost/Account/id
        [HttpGet]
        public IActionResult Register()
        {
            //show view with empty text boxes for name, dob, email, password
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserRegisterRequestModel model)
        {
            //check for model validation on server also
            if (ModelState.IsValid)
            {
                //save to database
            }
            //take name, dob, email, password from view to database
            return View();
        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class AccountController : Controller
    {
        //localhost/Account/id
        [HttpGet]
        public IActionResult Account(int id)
        {
            return View();
        }

        //localhost/Account
        [HttpGet]
        public IActionResult Account()
        {
            return View();
        }

        [HttpPost]
        public void PostAccount()
        {
           
        }

        [HttpPost]
        public void PostLogin()
        {

        }
    }
}

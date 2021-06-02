using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class CastController : Controller
    {  
        //localhost/Cast
        [HttpGet]
        public IActionResult Cast(int id)
        {
            return View();
        }
    }
}

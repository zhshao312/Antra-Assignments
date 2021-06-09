using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class GenreController : Controller
    {
        //localhost/Genres
        [HttpGet]
        public IActionResult Genre()
        {
            return View();
        }
    }
}

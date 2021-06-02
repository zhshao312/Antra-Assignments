using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class GenresController : Controller
    {
        //localhost/Genres
        [HttpGet]
        public IActionResult Genres()
        {
            return View();
        }
    }
}

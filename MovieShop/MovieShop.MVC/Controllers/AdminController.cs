using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class AdminController : Controller
    {
        //localhost/Admin/Movie
        [HttpGet]
        public IActionResult Purchases()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostMovie()
        {
            return View("Index");
        }

        [HttpPut]
        public ActionResult PutMovie()
        {
            return View("Index");
        }
    }
}

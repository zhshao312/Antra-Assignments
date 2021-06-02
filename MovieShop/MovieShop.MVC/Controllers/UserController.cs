using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {
        //localhost/User/id/movie/id/Favorite
        [HttpGet]
        public IActionResult Favorite(int userId, int movieId)
        {
            return View();
        }

        //localhost/User/id/purchases
        [HttpGet]
        public IActionResult Purchases(int id)
        {
            return View();
        }

        //localhost/User/id/Favorites
        [HttpGet]
        public IActionResult Favorites(int id)
        {
            return View();
        }

        //localhost/User/id/reviews
        [HttpGet]
        public IActionResult reviews(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostPurchase()
        {
            return View("Index");
        }
        [HttpPost]
        public IActionResult PostFavorite()
        {
            return View("Index");
        }
        [HttpPost]
        public IActionResult PostUnfavorite()
        {
            return View("Index");
        }
        [HttpPost]
        public IActionResult PostReview()
        {
            return View("Index");
        }

        [HttpPut]
        public IActionResult PutReview()
        {
            return View("Index");
        }

        [HttpDelete]
        public IActionResult DeleteReview(int userId, int movieId)
        {
            return View("Index");
        }
    }

}

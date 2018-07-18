using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentABike.Logic.Interfaces;

namespace RentABike.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBikeService _bikeService;

        public HomeController(IBikeService bikeService)
        {
            _bikeService = bikeService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var bikes = _bikeService.Bikes();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentABike.Logic.Interfaces;
using RentABike.Models;

namespace RentABike.Website.Controllers
{
    public class BikeTypeController : Controller
    {
        private readonly IBikeTypeService _bikeTypeService;

        public BikeTypeController(IBikeTypeService bikeTypeService)
        {
            _bikeTypeService = bikeTypeService;
        }

        [HttpGet]
        public ActionResult AllTypeOfBikes()
        {
            var bikeTypes = _bikeTypeService.AllBikeTypes();

            return View(bikeTypes);
        }
    }
}
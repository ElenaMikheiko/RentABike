using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using RentABike.Logic.Interfaces;
using RentABike.Models;

namespace RentABike.Website.Controllers
{
    public class TypeOfBikeController : Controller
    {
        private readonly IBikeTypeService _bikeTypeService;

        private readonly IBikeService _bikeService;

        public TypeOfBikeController(IBikeTypeService bikeTypeService, IBikeService bikeService)
        {
            _bikeTypeService = bikeTypeService;
            _bikeService = bikeService;
        }

        [HttpGet]
        public ActionResult CreateNewTypeOfBike()
        {
            return PartialView("_CreateTypeOfBike", new BikeType());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewTypeOfBike(BikeType bikeType)
        {
            if (ModelState.IsValid)
            {
                bool isNew = bikeType.Id == 0;
                _bikeTypeService.SaveBikeType(bikeType);
                int id = 0;
                var biketype = _bikeTypeService.AllBikeTypes().FirstOrDefault(x => x.Type == bikeType.Type);
                if (biketype != null)
                {
                    id = biketype.Id;
                }
                return Json(new
                {
                    isValid = true,
                    id = id,
                    name = bikeType.Type,
                    isNew = isNew
                });
            }

            return Json(new
            {
                isValid = false
            });
        }

        [HttpGet]
        public ActionResult AllTypeOfBikes()
        {
            var bikeTypes = _bikeTypeService.AllBikeTypes();

            return View(bikeTypes);
        }

        public ActionResult ShowBikesOfType(int biketypeid)
        {
            var bikes = _bikeService.GetBikesByBikeTypeId(biketypeid);

            return View(bikes);
        }
    }
}
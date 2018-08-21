using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using RentABike.Common.Interfaces;
using RentABike.Logic.Interfaces;
using RentABike.Models;
using RentABike.ViewModels;

namespace RentABike.Website.Controllers
{
    public class TypeOfBikeController : Controller
    {
        private readonly IBikeTypeService _bikeTypeService;

        private readonly IBikeService _bikeService;

        private readonly ITarriffService _tarriffService;

        private readonly IKindOfRentService _kindOfRentService;

        public TypeOfBikeController(IBikeTypeService bikeTypeService, IBikeService bikeService, ITarriffService tarriffService,
        IKindOfRentService kindOfRentService)
        {
            _bikeTypeService = bikeTypeService;
            _bikeService = bikeService;
            _tarriffService = tarriffService;
            _kindOfRentService = kindOfRentService;
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

        public ActionResult DeleteTypeOfBike(int bikeTypeId)
        {
            //_bikeTypeService.DeleteBikeType(bikeTypeId);
            var bikeType = _bikeTypeService.GetBikeTypeById(bikeTypeId);
            return PartialView("_DeleteBikeType", bikeType);
        }

        public ActionResult ConfirmDelete(int bikeTypeId)
        {
            bool result = false;
            var bikeType = _bikeTypeService.GetBikeTypeById(bikeTypeId);
            if (bikeType != null)
            {
                _bikeTypeService.DeleteBikeType(bikeTypeId);
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }
}
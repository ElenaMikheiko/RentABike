using System;
using System.Linq;
using System.Web.Mvc;
using RentABike.Common.Interfaces;
using RentABike.ViewModels;

namespace RentABike.Website.Controllers
{
    public class BikeController : Controller
    {
        private readonly IBikeTypeService _bikeTypeService;

        private readonly IRentPointService _rentPointService;

        private readonly IBikeRentPointService _bikeRentPointService;

        private readonly IBikeService _bikeService;

        private readonly ITarriffService _tarriffService;


        public BikeController(IRentPointService rentPointService, IBikeTypeService bikeTypeService, 
                              IBikeRentPointService bikeRentPointServiceService, IBikeService bikeService,
                              ITarriffService tarriffService)
        {
            _rentPointService = rentPointService;
            _bikeTypeService = bikeTypeService;
            _bikeRentPointService = bikeRentPointServiceService;
            _bikeService = bikeService;
            _tarriffService = tarriffService;
        }

        [HttpGet]
        public ActionResult AllBikes()
        {

            var bikes = _bikeService.Bikes();


            return View(bikes);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var bike = _bikeService.GetBikeById(id);

            var vm = new DetailsBikeViewModel
            {
                Model = bike.Model,
                BikeId = id,
                BikeTypeId = bike.BikeTypeId,
                BikeType = bike.BikeType,
                Description = bike.Description,
                Image = bike.Image,
                RentPoints = bike.RentPoints
            };

            var tarriffsForBikeType = _tarriffService.GetAllTarriffsByBikeTypeId(bike.BikeTypeId).ToList();
            var tarriffForOneHour = tarriffsForBikeType
                .FirstOrDefault(t => t.KindOfRent.Kind == "hour(s)" && t.Quantity == 1);
            var tarriffForOneDay = tarriffsForBikeType
                .FirstOrDefault(t => t.KindOfRent.Kind == "day(s)" && t.Quantity == 1);

            if (tarriffForOneHour != null && tarriffForOneDay!=null)
            {
                vm.TarrifForOneHour = tarriffForOneHour.Amount;
                vm.TarrifForOneDay = tarriffForOneDay.Amount;
            }

            return View(vm);
        }

        [HttpGet]
        public ActionResult CreateNewBike()
        {
            var bike = new CreationBikeViewModel
            {
                BikeTypes = _bikeTypeService.AllBikeTypes(),
                RentPoints = _rentPointService.AllRentPoint()
            };

            return View(bike);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewBike(CreationBikeViewModel vm)
        {
            if (string.IsNullOrEmpty(vm.Base64Image))
            {
                ModelState.AddModelError("Image", "You must upload the image");
            }

            if (ModelState.IsValid)
            {
                Server.HtmlEncode(vm.Description);
                    _bikeRentPointService.SaveBikeAndRentPoint(vm);

                    return RedirectToAction("Index", "Home");
                }

                vm.BikeTypes = _bikeTypeService.AllBikeTypes();
                vm.RentPoints = _rentPointService.AllRentPoint();

            return View(vm);
        }

        public ActionResult Edit(int id)
        {
            var editBike = new EditBikeViewModel();
            var bike = _bikeService.GetBikeByIdIncludingBikeType(id);
            editBike.BikeId = id;
            editBike.BikeModel = bike.Model;
            editBike.Description = bike.Description;
            if (bike.Image != null)
            {
                editBike.Base64Image = Convert.ToBase64String(bike.Image);
            }
            editBike.BikeTypeId = bike.BikeTypeId;
            editBike.BikeTypes = _bikeTypeService.AllBikeTypes();
            editBike.RentPoints = _rentPointService.AllRentPoint();
            editBike.RentPointsWhereBikeIsExist = bike.RentPoints;

            return View(editBike);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditBikeViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _bikeService.UpdateBike(vm);

                return RedirectToAction("Index", "Home");
            }
            var bike = _bikeService.GetBikeByIdIncludingBikeType(vm.BikeId);
            vm.BikeTypes = _bikeTypeService.AllBikeTypes();
            vm.RentPoints = _rentPointService.AllRentPoint();
            vm.RentPointsWhereBikeIsExist = bike.RentPoints;


            return View(vm);
        }

        public ActionResult Delete(int id)
        {
            var bike = _bikeService.GetBikeById(id);

            return PartialView("Delete",bike);
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            bool result = false;
            var bike = _bikeService.GetBikeById(id);
            if (bike != null)
            {
                _bikeService.DeleteBike(bike);
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
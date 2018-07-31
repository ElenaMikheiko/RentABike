using System;
using System.Web;
using System.Web.Mvc;
using RentABike.Logic.Interfaces;
using RentABike.Models;
using RentABike.ViewModels;

namespace RentABike.Website.Controllers
{
    public class BikeController : Controller
    {
        private readonly IBikeTypeService _bikeTypeService;

        private readonly IRentPointService _rentPointService;

        private readonly IBikeRentPointService _bikeRentPointService;

        public BikeController(IRentPointService rentPointService, IBikeTypeService bikeTypeService, IBikeRentPointService bikeRentPointServiceService)
        {
            _rentPointService = rentPointService;
            _bikeTypeService = bikeTypeService;
            _bikeRentPointService = bikeRentPointServiceService;
        }


        // GET: Bike
        public ActionResult Index()
        {
            return View();
        }

        // GET: Bike/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

        // POST: Bike/Create
        [HttpPost]
        public ActionResult CreateNewBike(CreationBikeViewModel vm)
        {
            //try
            //{
                // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                _bikeRentPointService.SaveBikeAndRentPoint(vm);

            }

            return RedirectToAction(nameof(Index), "Home");
            //}
            //catch
            //{
            //vm.BikeTypes = _bikeTypeService.AllBikeTypes();
            //    vm.RentPoints = _rentPointService.AllRentPoint();
            //    return View(vm);
            //}
        }

        // GET: Bike/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bike/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bike/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bike/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
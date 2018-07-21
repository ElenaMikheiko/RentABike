using System.Web.Mvc;
using RentABike.Logic.Interfaces;
using RentABike.ViewModels;

namespace RentABike.Website.Controllers
{
    public class BikeController : Controller
    {
        private readonly IBikeTypeService _bikeTypeService;
        private readonly IRentPointService _rentPointService;

        public BikeController(IRentPointService rentPointService, IBikeTypeService bikeTypeService)
        {
            _rentPointService = rentPointService;
            _bikeTypeService = bikeTypeService;
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

        // GET: Bike/Create
        public ActionResult CreateNewBike()
        {
            var bike = new CreateBikeViewModel
            {
                BikeTypes = _bikeTypeService.AllBikeTypes(),
                RentPoints = _rentPointService.AllRentPoint()
            };

            return View(bike);
        }

        // POST: Bike/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
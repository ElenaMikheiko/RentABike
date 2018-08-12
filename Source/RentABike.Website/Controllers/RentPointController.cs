using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using RentABike.Logic.Interfaces;
using RentABike.ViewModels;

namespace RentABike.Website.Controllers
{
    public class RentPointController : Controller
    {
        private readonly IRentPointService _rentPointService;

        public RentPointController(IRentPointService rentPointService)
        {
            _rentPointService = rentPointService;
        }

        [HttpGet]
        public ActionResult CreateNewRentPoint()
        {
            return PartialView("_CreateRentPoint", new RentPointViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewRentPoint(RentPointViewModel vm)
        {
            if (ModelState.IsValid)
            {
                bool isNew = vm.RentPointId == 0;
                _rentPointService.AddRentPoint(vm);
                int id=0;
                var rentpoint = _rentPointService.AllRentPoint().FirstOrDefault(r => r.Address == vm.Address);
                if (rentpoint != null)
                {
                    id = rentpoint.Id;
                }

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(vm.Name + ", " + vm.Address);
                return Json(new
                {
                    isValid = true,
                    id = id,
                    name = sb.ToString() ,
                    isNew = isNew
                });
            }

            return Json(new
            {
                isValid = false
            });
        }

        [HttpGet]
        public ActionResult AllRentPoint()
        {
            var rentPoints = _rentPointService.AllRentPoint();
            return View(rentPoints);
        }

    }
}
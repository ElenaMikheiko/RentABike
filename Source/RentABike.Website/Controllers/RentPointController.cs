using System.Linq;
using System.Text;
using System.Web.Mvc;
using RentABike.Common.Interfaces;
using RentABike.Models;
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

        [HttpGet]
        public ActionResult EditRentPoint(int rentPointId)
        {
            var rentPoint = _rentPointService.GetRentPointById(rentPointId);

            return PartialView("EditRentPoint",rentPoint);
        }

        [HttpPost]
        public ActionResult EditRentPoint(RentPoint model)
        {
            var existingRentPoint = _rentPointService.GetRentPointById(model.Id);
            if (existingRentPoint != null)
            {
                existingRentPoint.Address = model.Address;
                existingRentPoint.Name = model.Name;
                existingRentPoint.Phone = model.Phone;
            }

            _rentPointService.UpdateRentPoint(existingRentPoint);

            return RedirectToAction("PersonalAccount","Account");
        }

        [HttpGet]
        public ActionResult DeleteRentPoint(int rentPointId)
        {
            var rentPoint = _rentPointService.GetRentPointById(rentPointId);

            return PartialView("_DeleteRentPoint", rentPoint);
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int rentPointId)
        {
            bool result = false;
            var rentPoint = _rentPointService.GetRentPointById(rentPointId);
            if (rentPoint != null)
            {
                rentPoint.Bikes.Clear();
                rentPoint.Sellers.Clear();
                _rentPointService.DeleteRentPoint(rentPoint);
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }

    }
}
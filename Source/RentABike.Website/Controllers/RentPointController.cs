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
        public ActionResult CreateNewRentPoint(RentPointViewModel vm)
        {
            _rentPointService.AddRentPoint(vm);
            return Json(vm, JsonRequestBehavior.AllowGet);
        }

    }
}
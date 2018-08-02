using System;
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
        public JsonResult CreateNewRentPoint(RentPointViewModel vm)
        {
            _rentPointService.AddRentPoint(vm);
            JsonResult result = new JsonResult();
            //Попытка сохранить данные в БД
            try
            {
                //......................
                result.Data = new { Succes = "true", Message = "Данные сохранены." };
            }
            catch (Exception e)
            {
                result.Data = new { Succes = "false", Message = "Данные не сохранены." };
            }
            return result;
        }

        [HttpGet]
        public ActionResult AllRentPoint()
        {
            var rentPoints = _rentPointService.AllRentPoint();
            return View(rentPoints);
        }
    }
}
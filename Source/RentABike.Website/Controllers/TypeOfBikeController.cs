using System;
using System.Web.Mvc;
using RentABike.Logic.Interfaces;
using RentABike.Models;

namespace RentABike.Website.Controllers
{
    public class TypeOfBikeController : Controller
    {
        private readonly IBikeTypeService _bikeTypeService;

        public TypeOfBikeController(IBikeTypeService bikeTypeService)
        {
            _bikeTypeService = bikeTypeService;
        }

        [HttpGet]
        public ActionResult CreateNewTypeOfBike()
        {
            return PartialView("_CreateTypeOfBike", new BikeType());
        }

        [HttpPost]
        public JsonResult CreateNewTypeOfBike(BikeType bikeType)
        {
            _bikeTypeService.SaveBikeType(bikeType);
            var result = new JsonResult();
            //Попытка сохранить данные в БД
            try
            {
                //......................
                result.Data = new {Succes = "true", Message = "Данные сохранены."};
            }
            catch (Exception e)
            {
                result.Data = new {Succes = "false", Message = "Данные не сохранены."};
            }

            return result;
        }
    }
}
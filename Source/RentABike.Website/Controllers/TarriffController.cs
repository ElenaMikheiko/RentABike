using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RentABike.Common.Interfaces;
using RentABike.Logic.Interfaces;
using RentABike.Models;
using RentABike.Models.Constants;
using RentABike.ViewModels;

namespace RentABike.Website.Controllers
{
    public class TarriffController : Controller
    {
        private readonly IBikeTypeService _bikeTypeService;

        private readonly ITarriffService _tarriffService;

        private readonly IKindOfRentService _kindOfRentService;

        public TarriffController(IBikeTypeService bikeTypeService, ITarriffService tarriffService, IKindOfRentService kindOfRentService)
        {
            _bikeTypeService = bikeTypeService;
            _tarriffService = tarriffService;
            _kindOfRentService = kindOfRentService;
        }

        // GET: Tarriff
        public ActionResult Index()
        {
            var allBikeTypes = _bikeTypeService.AllBikeTypes();

            var vm = new List<TarriffsForBikeTypesViewModel>();

            foreach (var bikeType in allBikeTypes)
            {
                var tarriffForDays = _tarriffService.GetAllDaysTarriffsByBikeTypeId(bikeType.Id).ToList();
                var tarriffForHours = _tarriffService.GetAllHoursTarriffsByBikeTypeId(bikeType.Id).ToList();

                vm.Add(new TarriffsForBikeTypesViewModel
                                                        {
                                                            BikeType = bikeType,
                                                            TarriffsForDays = tarriffForDays,
                                                            TarriffsForHours = tarriffForHours
                                                        });
            }

            return View(vm);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateNewTarriff(int bikeTypeId, string kindOfRent)
        {
            var vm = new TarriffViewModel
            {
                BikeType = _bikeTypeService.GetBikeTypeById(bikeTypeId),
                Tarriffs = new List<TarriffForEdit>(),
                IsNew = true
            };
            switch (kindOfRent)
            {
                case "hour(s)":
                    for (int i = 0; i < 5; i++)
                    {
                       var k = i;

                        var tarriff = new TarriffForEdit
                        {
                            KindOfRent = _kindOfRentService.GetKindOfRentByName(kindOfRent),
                            Quantity = ++k
                        };
                        vm.Tarriffs.Add(tarriff);
                    }

                    break;
                case "day(s)":
                    for (int i = 0; i < 3; i++)
                    {
                        var k = i;

                        var tarriff = new TarriffForEdit
                        {
                            KindOfRent = _kindOfRentService.GetKindOfRentByName(kindOfRent),
                            Quantity = ++k
                        };
                        vm.Tarriffs.Add(tarriff);
                    }
                    break;
            }

            return PartialView("_Tarriff", vm);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditTarriff(int bikeTypeId, string kindOfRent)
        {
            var vm = new TarriffViewModel();
            vm.BikeType = _bikeTypeService.GetBikeTypeById(bikeTypeId);
            var tarriffByBikeType = _tarriffService.GetAllTarriffsByBikeTypeId(vm.BikeType.Id);
            vm.Tarriffs = new List<TarriffForEdit>();
            vm.IsNew = false;
            IEnumerable<Tarriff> tarriffs  = new List<Tarriff>();
            switch (kindOfRent)
            {
                case "hour(s)":
                    tarriffs = tarriffByBikeType.Where(t => t.KindOfRent.Kind == "hour(s)");
                    break;
                case "day(s)":
                    tarriffs = tarriffByBikeType.Where(t => t.KindOfRent.Kind == "day(s)");
                    break;
            }
            foreach (var tarriffEdit in tarriffs)
            {

                var tarriff = new TarriffForEdit
                {
                    KindOfRent = _kindOfRentService.GetKindOfRentByName(kindOfRent),
                    Quantity = tarriffEdit.Quantity,
                    Amount = tarriffEdit.Amount
                };
                vm.Tarriffs.Add(tarriff);
            }
            return PartialView("_Tarriff", vm);

        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult SaveTarriff(TarriffViewModel vm)
        {
            if (vm.IsNew)
            {
                _tarriffService.CreateNewTarriff(vm);
            }
            else
            {
                _tarriffService.UpdateTarriff(vm);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int bikeTypeId, string kindOfRent)
        {
            _tarriffService.DeleteTarriffByBikeTypeIdAndKindOfRent(bikeTypeId, kindOfRent);

            return RedirectToAction("Index");
        }
    }
}
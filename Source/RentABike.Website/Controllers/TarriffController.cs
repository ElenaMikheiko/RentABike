using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentABike.Logic.Interfaces;
using RentABike.ViewModels;

namespace RentABike.Website.Controllers
{
    public class TarriffController : Controller
    {
        private readonly IBikeTypeService _bikeTypeService;

        private readonly ITarriffService _tarriffService;

        public TarriffController(IBikeTypeService bikeTypeService, ITarriffService tarriffService)
        {
            _bikeTypeService = bikeTypeService;
            _tarriffService = tarriffService;
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
    }
}
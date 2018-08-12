using System;
using System.Linq;
using System.Web.Mvc;
using NLog;
using RentABike.Logic.Interfaces;
using PagedList;

namespace RentABike.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBikeService _bikeService;

        private readonly IRentPointService _rentPointService;

        private readonly IBikeTypeService _bikeTypeService;

        public HomeController(IBikeService bikeService, IRentPointService rentPointService, IBikeTypeService bikeTypeService)
        {
            _bikeService = bikeService;
            _rentPointService = rentPointService;
            _bikeTypeService = bikeTypeService;
        }

        public ActionResult Index(string currentFilter, string searchString, int? page, int? rentPointFilter, int? bikeTypeFilter)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var bikes = _bikeService.Bikes();

            
            //search
            if (!String.IsNullOrEmpty(searchString))
            {
                bikes = bikes.Where(s => s.BikeType.Type.Contains(searchString)
                                         || s.Model.Contains(searchString));
            }

            //filter
            if (rentPointFilter != null && bikeTypeFilter != null)
            {
                bikes = bikes.SelectMany(bike => bike.RentPoints,
                        (bike, rentPoint) => new { Bike = bike, RentPont = rentPoint }).Where(bike =>
                        bike.RentPont.Id == rentPointFilter && bike.Bike.BikeTypeId == bikeTypeFilter)
                    .Select(bike => bike.Bike);
            }
            else if (rentPointFilter != null || bikeTypeFilter != null)
            {
                bikes = bikes.SelectMany(bike => bike.RentPoints,
                        (bike, rentPoint) => new { Bike = bike, RentPont = rentPoint }).Where(bike =>
                        bike.RentPont.Id == rentPointFilter || bike.Bike.BikeTypeId == bikeTypeFilter)
                    .Select(bike => bike.Bike);
            }

            if (rentPointFilter != null)
            {
                ViewBag.RentPointFilter = rentPointFilter;

            }
            else if (bikeTypeFilter != null)
            {
                ViewBag.BikeTypeFilter = bikeTypeFilter;
            }

            //paging
            int pageSize = 4;
            int pageNumber = (page ?? 1);


            //filters
            //dropdownlists
            ViewData["rentPoint"] = _rentPointService.AllRentPoint();
            ViewData["bikeType"] = _bikeTypeService.AllBikeTypes();

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Bikes", bikes.ToPagedList(pageNumber, pageSize));
            }

            return View(bikes.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}
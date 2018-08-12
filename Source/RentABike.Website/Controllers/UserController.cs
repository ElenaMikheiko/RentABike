using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RentABike.Logic;
using RentABike.Logic.Interfaces;
using RentABike.ViewModels;

namespace RentABike.Website.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserInfoService _userInfoService;

        private ApplicationUserManager _userManager;

        private RoleManager<IdentityRole> _roleManager;

        public UserController(IUserInfoService userInfoService, ApplicationUserManager userManager, RoleManager<IdentityRole> roleManager)
        {
            _userInfoService = userInfoService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public ActionResult AllUsers()
        {
            var allUserInfos = _userInfoService.AllUserInfos();
            var vmList = new List<UserInfoViewModel>();
            foreach (var userInfo in allUserInfos)
            {
                var info = new UserInfoViewModel()
                {
                    Name = userInfo.Name,
                    UserEmail = userInfo.Email,
                    Surname = userInfo.Surname,
                    UserPhone = userInfo.Phone,
                    UserRole = _userManager.GetRoles(userInfo.User.Id).FirstOrDefault(),
                    UserInfoId = userInfo.Id

                };
                vmList.Add(info);
            }
            var roles = _roleManager.Roles.ToList();
            return View(vmList);
        }

        public ActionResult ShowAllSellersInRentPoint(int rentpointid)
        {
            var sellers = _userManager.Users.Where(u => u.RentPoint.Id == rentpointid).ToList();

            List<UserInfoViewModel> userInfos = new List<UserInfoViewModel>();
            foreach (var seller in sellers)
            {
                var userInfo = _userInfoService.GetUserInfoByUserId(seller.Id);

                userInfos.Add(new UserInfoViewModel
                {
                    Name = userInfo.Name,
                    Surname = userInfo.Surname,
                    Patronymic = userInfo.Patronymic,
                    UserPhone = userInfo.Phone,
                    ImageData = userInfo.Photo,
                    UserEmail = userInfo.Email,
                    UserRole = _userManager.GetRoles(seller.Id).FirstOrDefault()
                });
            }

            return PartialView("AllUsers", userInfos);
        }

    }
}
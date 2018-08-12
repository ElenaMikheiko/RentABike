using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using RentABike.Logic;
using RentABike.Logic.Interfaces;
using RentABike.Models;
using RentABike.Models.Constants;
using RentABike.ViewModels;

namespace RentABike.Website.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;

        private ApplicationUserManager _userManager;

        private IUserInfoService _userInfoService;

        private RoleManager<IdentityRole> _roleManager;

        private IRentPointService _rentPointService;

        private IUserInfoAndRentPointService _userInfondRentPointService;

        public AccountController(ApplicationUserManager userManager,
            ApplicationSignInManager signInManager, IUserInfoService userInfoService, RoleManager<IdentityRole> roleManager,
            IRentPointService rentPointService, IUserInfoAndRentPointService userInfoAndRentPointService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userInfoService = userInfoService;
            _roleManager = roleManager;
            _rentPointService = rentPointService;
            _userInfondRentPointService = userInfoAndRentPointService;
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [ChildActionOnly]
        [AllowAnonymous]
        public ActionResult NavbarLogin()
        {
            var vm = new LoginViewModel();

            return this.PartialView("_NavbarLogin", vm);
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            var vm = new RegisterViewModel();
            vm.Roles = _roleManager.Roles.ToList();
            return View(vm);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var userInfo = new UserInfo
                {
                    Id = user.Id,
                    Surname = model.Surname,
                    Phone = model.Phone,
                    Patronymic = model.Patronymic,
                    Name = model.Name,
                    Email = model.Email
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                _userInfoService.CreateUserInfo(userInfo);

                if (result.Succeeded)
                {
                    if (model.RoleId == null)
                    {
                        await _userManager.AddToRoleAsync(user.Id, "User");
                        await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                        // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                        // Send an email with this link
                        // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                        // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                        // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        var role = _roleManager.Roles.FirstOrDefault(r => r.Id == model.RoleId);
                        if (role != null)
                        {
                            await _userManager.AddToRoleAsync(user.Id, role.Name);
                        }
                        
                        return RedirectToAction("PersonalAccount", "Account");
                    }
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await _userManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await _userManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion

        [HttpGet]
        [Authorize]
        public ActionResult PersonalAccount()
        {
            var vm = new UserInfoViewModel();
            var user = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(User.Identity.GetUserId());
            var userInfo = _userInfoService.GetUserInfoByUserId(user.Id);

            vm.UserEmail = user.Email.ToLower();
            StringBuilder sb = new StringBuilder(String.Concat(userInfo.Name, " ", userInfo.Surname));
            vm.UserFullName = sb.ToString();
            vm.UserPhone = userInfo.Phone;
            vm.ImageData = userInfo.Photo;
            vm.UserRole = _userManager.GetRoles(user.Id).FirstOrDefault();

            return View(vm);
        }

        [Authorize]
        [ChildActionOnly]
        public ActionResult UserInfo(string userEmail)
        {
            var vm = new UserInfoViewModel();
            var user = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(User.Identity.GetUserId());
            var userInfo = _userInfoService.GetUserInfoByUserId(user.Id);
            vm.UserEmail = user.Email.ToLower();
            StringBuilder sb = new StringBuilder(String.Concat(userInfo.Name," ", userInfo.Surname));
            vm.UserFullName = sb.ToString();
            vm.UserPhone = userInfo.Phone;
            vm.ImageData = userInfo.Photo;

            return this.PartialView("_NavbarUserInfo", vm);
        }

        [HttpGet]
        [Authorize]
        public ActionResult ChangePersonalInfo()
        {
            var userId = User.Identity.GetUserId();
            var viewModel = new EditPersonalUserInfoViewModel();
            viewModel.UserId = userId;
            var userInfo = _userInfoService.GetUserInfoByUserId(userId);
            if (userInfo != null)
            {
                viewModel.Name = userInfo.Name;
                viewModel.Surname = userInfo.Surname;
                viewModel.Patronymic = userInfo.Patronymic;
                viewModel.Email = userInfo.Email;
                viewModel.Phone = userInfo.Phone;
                if (userInfo.Photo != null)
                {
                    viewModel.Base64Image = Convert.ToBase64String(userInfo.Photo);
                }
            }

            viewModel.RentPoints = _rentPointService.AllRentPoint();

            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePersonalInfo(EditPersonalUserInfoViewModel vm)
        {
            if (User.IsInRole(Roles.Seller))
            {
                if (vm.RentPointId==0)
                {
                    ModelState.AddModelError("Rent point", "You must to fill in field Rent Point");
                }
            }

            if (ModelState.IsValid)
            {
                vm.UserId = User.Identity.GetUserId();

                _userInfondRentPointService.SaveUserInfoAndRentPoint(vm);
                return RedirectToAction("PersonalAccount", "Account");
            }

            return View(vm);
        }

    }
}
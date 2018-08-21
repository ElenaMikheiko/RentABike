﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Ninject;
using Ninject.Web.Common;
using RentABike.Common.Interfaces;
using RentABike.DataProvider;
using RentABike.DataProvider.Interfaces;
using RentABike.DataProvider.Repositories;
using RentABike.Logic;
using RentABike.Logic.Interfaces;
using RentABike.Models;

namespace RentABike.IoC
{
    public class NInjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NInjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.Get(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<ApplicationUserManager>().ToSelf().InRequestScope();

            _kernel.Bind<ApplicationSignInManager>().ToSelf().InRequestScope();

            _kernel.Bind<RentABikeDbContext>().ToSelf().InRequestScope();

            _kernel.Bind<IRoleStore<IdentityRole, string>>()
                .ToMethod(x => new RoleStore<IdentityRole, string, IdentityUserRole>(x.Kernel.Get<RentABikeDbContext>()))
                .InRequestScope();

            _kernel.Bind<RoleManager<IdentityRole>>().ToSelf();
            _kernel.Bind<IUserStore<ApplicationUser>>()
                .ToMethod(x => new UserStore<ApplicationUser>(x.Kernel.Get<RentABikeDbContext>()))
                .InRequestScope();

            _kernel.Bind<IAuthenticationManager>()
                .ToMethod(x => HttpContext.Current.GetOwinContext().Authentication)
                .InRequestScope();

            _kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>)).InRequestScope();
            _kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            _kernel.Bind<IBikeService>().To<BikeService>();
            _kernel.Bind<IRentPointService>().To<RentPointService>();
            _kernel.Bind<IBikeTypeService>().To<BikeTypeService>();
            _kernel.Bind<IBikeRentPointService>().To<BikeRentPointService>();
            _kernel.Bind<IUserInfoService>().To<UserInfoService>();
            _kernel.Bind<IOrderService>().To<OrderService>();
            _kernel.Bind<IStatusService>().To<StatusService>();
            _kernel.Bind<ITarriffService>().To<TarriffService>();
            _kernel.Bind<IUserInfoAndRentPointService>().To<UserInfoRentPointService>();
            _kernel.Bind<IKindOfRentService>().To<KindOfRentService>();

        }
    }
}
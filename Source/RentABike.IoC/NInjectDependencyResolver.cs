using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Ninject.Web.Common;
using RentABike.DataProvider.Interfaces;
using RentABike.DataProvider.Repositories;
using RentABike.Logic;
using RentABike.Logic.Interfaces;

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
            _kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>)).InRequestScope();
            _kernel.Bind<IBikeService>().To<BikeService>();
            _kernel.Bind<IRentPointService>().To<RentPointService>();
            _kernel.Bind<IBikeTypeService>().To<BikeTypeService>();
        }
    }
}
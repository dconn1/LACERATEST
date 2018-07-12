using Ninject;
using Ninject.Concrete;
using Ninject.Interface;
using System;
using System.Collections.Generic;

namespace LACERAMVC.App_Start
{
    public class NinjectResolver : System.Web.Mvc.IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IEmployee, Employee>();   
        }
    }
}
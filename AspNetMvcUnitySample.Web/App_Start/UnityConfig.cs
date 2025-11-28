using AspNetMvcUnitySample.CommonLibrary;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace AspNetMvcUnitySample.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            Assembly.GetExecutingAssembly().GetReferencedAssemblies()
                .Select(Assembly.Load)
                .ToList()
                .ForEach(x => container.RegisterByAttribute(x));

            // container.RegisterType<IValueService, ValueService>();
            // container.RegisterType(typeof(IValueService), typeof(ValueService));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
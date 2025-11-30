using System;
using Unity.Lifetime;

namespace AspNetMvcUnitySample.CommonLibrary.Services
{
    [RegisterDependency(typeof(HierarchicalLifetimeManager))]
    public class DisposableSample : IDisposable
    {
        public string GetInfo()
        {
            return "This is DisposableSample class.";
        }

        public void Dispose()
        {
            Console.WriteLine("Execute DisposableSample dispose.");
        }
    }
}

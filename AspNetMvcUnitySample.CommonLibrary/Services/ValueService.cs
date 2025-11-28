using AspNetMvcUnitySample.CommonLibrary.Services.Interfaces;

namespace AspNetMvcUnitySample.CommonLibrary.Services
{
    public class ValueService : IValueService
    {
        public string GetValue()
        {
            return "Hello from ValueService";
        }
    }
}
namespace AspNetMvcUnitySample.CommonLibrary.Services
{
    [RegisterDependency]
    public class SampleService
    {
        public string GetMessage()
        {
            return "Hello from SampleService.";
        }
    }
}

using System.Web.Mvc;
using AspNetMvcUnitySample.CommonLibrary.Services;
using AspNetMvcUnitySample.CommonLibrary.Services.Interfaces;

namespace AspNetMvcUnitySample.Web.Controllers
{
    public class HomeController(IValueService valueService, SampleService sampleService) : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = valueService.GetValue();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = sampleService.GetMessage();

            return View();
        }
    }
}
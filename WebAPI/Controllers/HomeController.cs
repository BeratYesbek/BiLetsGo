using Business.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private ISalonService _salonSerice;
        public HomeController(ISalonService salonService)
        {

        }
        public IActionResult Index()
        {
            var data = _salonSerice.GetAll();
            ViewBag.Data = data.Data;
            return View(data);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index() => View();
    }
}
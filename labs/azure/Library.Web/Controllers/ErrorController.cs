using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("error")]
        public IActionResult Error()
        {
            return View();
        }

        [Route("error/{code}")]
        public IActionResult ErrorCode(string code)
        {
            return code switch
            {
                "404" => View("Error404"),
                _ => View((object) code)
            };
        }
    }
}
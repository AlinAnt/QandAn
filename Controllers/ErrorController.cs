using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Net;


namespace QandAn.Controllers
{
    public class ErrorController : Controller
    {     
        public IActionResult Index(int? code)
        {
            return View(code ?? (int) HttpStatusCode.InternalServerError);
        }
    }
}
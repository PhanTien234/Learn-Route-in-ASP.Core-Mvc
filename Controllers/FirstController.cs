using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        public FirstController(ILogger<FirstController> logger){
            _logger = logger;
        }
        public string Index()
        {
            //this.HttpContext
            //this.Request
            //this.Response
            //this.RouteData

            //this.User
            //this.ModelState
            //this.ViewData
            //this.ViewBag
            //this.Url

            // _logger.Log(LogLevel.Warning, "THong bao abc");
            _logger.LogWarning("Thong bao");
            _logger.LogError("Thong bao");
            _logger.LogDebug("Thong bao");
            _logger.LogCritical("Thong bao");
            _logger.LogInformation("Index Action");
            //Serilog

            // Console.WriteLine("Index Action");
            return "Toi la Index cua fisrt";
        }

        public void Nothing(){
            _logger.LogInformation("Nothing Action");
            Response.Headers.Add("hi", "xin chao cac ban");
        }

        public object Anything() => new int[] {1, 2, 3};
        public IActionResult Readme(){
            var content = @"
                Xin chao cac ban,
                cac ban dang hoc ve ASP.NET MVC


                XUANTHULAB.NET
            ";
            return Content(content, "text/plain");
        }

    //     Kiểu trả về                 | Phương thức
    //  IActionResult
    // ------------------------------------------------
    // ContentResult               | Content()
    // EmptyResult                 | new EmptyResult()
    // FileResult                  | File()
    // ForbidResult                | Forbid()
    // JsonResult                  | Json()
    // LocalRedirectResult         | LocalRedirect()
    // RedirectResult              | Redirect()
    // RedirectToActionResult      | RedirectToAction()
    // RedirectToPageResult        | RedirectToRoute()
    // RedirectToRouteResult       | RedirectToPage()
    // PartialViewResult           | PartialView()
    // ViewComponentResult         | ViewComponent()
    // StatusCodeResult            | StatusCode()
    // ViewResult                  | View()
    }
}
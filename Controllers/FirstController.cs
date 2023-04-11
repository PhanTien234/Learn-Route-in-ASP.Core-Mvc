using System.Collections.Immutable;
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
            return Content(content, "text/html");
        }

        // public IActionResult Flower(){
        //     //Startup.ContentRootPath
        //     string filePath = Path.Combine("Files", "picture1.jpg");
        //     var bytes = System.IO.File.ReadAllBytes(filePath);

        //     return File(bytes, "image/jpg");
        // }

        public IActionResult IPhonePrice()
        {
            return Json(
                new{
                    productName = "Iphone X",
                    Price = 1000
                }
            );
        }

        public IActionResult Privacy(){
            var url = Url.Action("Privacy", "Home");
            _logger.LogInformation("Chuyen huong den " + url);
            return LocalRedirect(url); // Local ~ host
        }
        public IActionResult Google(){
            var url = "https://google.com";
            _logger.LogInformation("Chuyen huong den " + url);
            return Redirect(url); // Local ~ host
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

        public IActionResult HelloView(){
            //View  => Razor engine, doc .cshtml (template)
            return View("/MyView/xinchao1.cshtml");
        }
    }
}
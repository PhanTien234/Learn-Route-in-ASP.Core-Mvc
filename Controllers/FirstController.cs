using System.Collections.Immutable;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, ProductService productService){
            _logger = logger;
            _productService = productService;
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

        public IActionResult HelloView(string username){
            if(string.IsNullOrEmpty(username))
                username = "Khach";
            
            
            //View  => Razor engine, doc .cshtml (template)
            //_______________________________________________
            // View(template) - template đường dẫn tuyệt đối tới cs.html
            //View(template, model

            //xinchao2.cshtml -> /View/First
            // return View("xinchao2", username);
            // return View("/MyView/xinchao1.cshtml", username);

            //HelloView.cshtml -> /View/First
            // /View/Controller/Action.cshtml
            // return View((object) username);

            return View("xinchao3", username);
            //View();
            //View(Model);

        }


        [TempData]
        public string StatusMessage {get; set;}

        public IActionResult ViewProduct(int? id){
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if(product == null){
                // TempData["StatusMessage"] = "San pham ban khong co";
                StatusMessage = "San pham ban yeu cau khong co";
                return Redirect(Url.Action("Index", "Home"));
            }




              //View/First/ViewProduct.cshtml
              //MyView/First/ViewProduct.cshtml
            // return View(product);
            
            //Trường hopej thứ hai để truyền dữ liệu từ Controller qua View ta sử dụng:
            //ViewData
            // this.ViewData["key"] = "value";
            // this.ViewData["product"] = product;
            // ViewData["Title"] = product.Name;
            // return View("ViewProduct2");

            TempData["Thongbao"] = "";            ViewBag.product = product;
            return View("ViewProduct3");
        }


    }
}
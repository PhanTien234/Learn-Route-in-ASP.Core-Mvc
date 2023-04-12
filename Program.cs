using System;
using System.Net;
using App.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing.Constraints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.Configure<RazorViewEngineOptions>(options => {
    // /View/Controller/Action.cshtml
    // /MyView/Controller/Action.cshtml

    // {0} -> name Action
    // {1} -> name Controller
    // {2} -> name Area
    options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
});

// builder.Services.AddSingleton<ProductService>();
// builder.Services.AddSingleton<ProductService, ProductService>();
// builder.Services.AddSingleton(typeof(ProductService));

builder.Services.AddSingleton(typeof(ProductService), typeof(ProductService));
builder.Services.AddSingleton<PlanetService>();
// builder.Services.AddTransient(typeof(ILogger<>), typeof(Logger<>)); Serilog
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// app.UseStatusCodePages(appError =>{
//     appError.Run(async context => {
//         var response = context.Response;
//         var code = response.StatusCode;

        
//         var content = @$"<html>
//             <head>
//                 <meta charset='UTF-8'/>
//                 <title>Loi {code} </title>
//             </head>
//             <body>
//                 <p style = 'color: red; font-size: 30px'>
//                     Co loi cay ra: {code} - { (HttpStatusCode)code}
//                 </p>

//             </body>
//         </html>";
//         await response.WriteAsync(content);
//     }); //400-500
// }); // EndpointRoutingMiddleware

app.UseRouting();

app.UseAuthorization();
// app.UseEndpoints(async endpoints =>{
//     //endoint sayhi
//     endpoints.MapGet("/sayhi", async (context) =>{
//         await context.Response.WriteAsync($"Hello ASP.NET MVC {DateTime.Now}");
//     });

//     // endpoints.MapRazorPages();
// });

// [AcceptVerbs]
// [Route]
// [HttpGet]
// [HttpPost]
// [HttpPut]
// [HttpDelete]
// [HttpHead]
// [HttpPatch]



//URL: /{controller}/{action}/{id?}
//Abc/Xyz => Controller =Abc, goi method Xyz
//Home/Index
//First/Index
// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

//URL = start-here/TenController/Action/id
// start-here/First/HelloView
// start-here/Home/Privacy
//controller =>
//action =>
//area =>

// app.MapControllers();

// //xemsanpham/1
// app.MapControllerRoute(
//     name:"first",
//     pattern:"{url:regex(^((xemsanpham)|(viewproduct))$)}/{id:range(2,4)}",//start-here, start-hear/1, start-hear/123
//     defaults: new{
//         controller = "First",
//         action = "ViewProduct"
//     }
    // constraints: new {
    //     //url = new RegexRouteConstraint(@"^((xemsanpham)|(viewproduct))$"),
    //     //id = new RangeRouteConstraint(2,4)
    // }


    
// );
// IRouteConstraint
// RegexRouteConstraint: xemsanpham hoac viewproduct
// url = "xemsanpham" // ~ new StringRouteConstraint("xemsanpha,)

// app.MapControllerRoute(
//     name:"default",
//     pattern:"start-here/{controller=Home}/{action=Index}/{id?}"//start-here, start-hear/1, start-hear/123

// );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

// app.MapControllerRoute
// app.MapController()
// app.MapDefaultControllerRoute
// app.MapAreaControllerRoute

app.Run();

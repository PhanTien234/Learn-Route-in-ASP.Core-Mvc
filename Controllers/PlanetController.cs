using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class PlanetController : Controller
    {
        private readonly PlanetService _planetService;
        private readonly ILogger<PlanetController> _logger;

        public PlanetController(PlanetService planetService, ILogger<PlanetController> logger)
        {
            _planetService = planetService;
            _logger = logger;
        }

        [Route("Danh sach cac hanh tinh.html")]
        public IActionResult Index()
        {
            return View();
        }
        
        // route: action
        [BindProperty(SupportsGet = true, Name ="action")]
        public string Name { get; set; } // action ~ PlanetModel
        public IActionResult Mercury()
        {
            var planet =_planetService.Where(x => x.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Venus()
        {
            var planet =_planetService.Where(x => x.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
                public IActionResult Earth()
        {
            var planet =_planetService.Where(x => x.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
                public IActionResult Mars()
        {
            var planet =_planetService.Where(x => x.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
                public IActionResult Jupiter()
        {
            var planet =_planetService.Where(x => x.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
                public IActionResult Saturn()
        {
            var planet =_planetService.Where(x => x.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Uranus()
        {
            var planet =_planetService.Where(x => x.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        [Route("sao")]
        public IActionResult Neptune()
        {
            var planet =_planetService.Where(x => x.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        //controller, action, area => [controller] [action] [area]
        [Route("hanhtinh/{id:int}")] // hanhtinh/id
        public IActionResult PlanetInfo(int id )
        {
            var planet =_planetService.Where(x => x.Id == id).FirstOrDefault();
            return View("Detail", planet);
        }
    }
}
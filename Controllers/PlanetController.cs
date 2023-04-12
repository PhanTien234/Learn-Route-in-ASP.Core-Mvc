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
    }
}
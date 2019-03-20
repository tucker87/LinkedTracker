using System.Collections.Generic;
using System.Diagnostics;
using LinkedTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace LinkedTracker.Controllers
{
    [Route("poi")]
    public class PointOfInterestController : Controller 
    {
        private readonly IPointOfInterestRepository _poiRepository;

        public PointOfInterestController(IPointOfInterestRepository poiRepository)
        {
            _poiRepository = poiRepository;
        }

        [Route("{game}/{pointOfInterestType}")]
        public IActionResult GetPointsOfInterest(string game, string pointOfInterestType)
        {
            return Json(_poiRepository.Get((game, pointOfInterestType)));
        }

        [Route("[action]")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
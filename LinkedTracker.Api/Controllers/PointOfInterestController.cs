using LinkedTracker.Data;
using Microsoft.AspNetCore.Mvc;

namespace LinkedTracker.Api.Controllers;

[Route("poi")]
public class PointOfInterestController : Controller 
{
    private readonly PointOfInterestRepository _poiRepository;

    public PointOfInterestController(PointOfInterestRepository poiRepository)
    {
        _poiRepository = poiRepository;
    }

    
}
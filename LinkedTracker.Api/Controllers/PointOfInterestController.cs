using LinkedTracker.Data;
using Microsoft.AspNetCore.Mvc;

namespace LinkedTracker.Api.Controllers;

[Route("poi")]
public class PointOfInterestController : Controller 
{
    private readonly IPointOfInterestRepository _poiRepository;

    public PointOfInterestController(IPointOfInterestRepository poiRepository)
    {
        _poiRepository = poiRepository;
    }

    
}
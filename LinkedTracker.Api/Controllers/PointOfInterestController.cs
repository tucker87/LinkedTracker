using LinkedTracker.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LinkedTracker.Api.Controllers;

[Route("poi")]
public class PointOfInterestController(PointOfInterestRepository poiRepository) : Controller 
{
    private readonly PointOfInterestRepository _poiRepository = poiRepository;
}
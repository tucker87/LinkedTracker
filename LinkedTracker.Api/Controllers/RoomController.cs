using System.Linq;
using System.Threading.Tasks;
using LinkedTracker.Api.Hubs;
using LinkedTracker.Api.Models;
using LinkedTracker.Data;
using LinkedTracker.Data.Models;
using LinkedTracker.Data.Repositories;
using LinkedTracker.Data.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace LinkedTracker.Api.Controllers;

[Route("[controller]")]
public class RoomController(
    RoomRepository roomRepository,
    PointOfInterestRepository pointOfInterestRepository,
    IHubContext<RoomHub, IRoomHub> roomHub) : Controller
{
    private readonly RoomRepository _roomRepository = roomRepository;
    private readonly PointOfInterestRepository _pointOfInterestRepository = pointOfInterestRepository;
    private readonly IHubContext<RoomHub, IRoomHub> _roomHub = roomHub;

    [HttpGet("{game}/{roomName}")]
    public IActionResult ViewRoom(string game, string roomName)
    {
        var key = (game, roomName);
        var room = _roomRepository.GetOrCreate(key, () => new Room(key));

        var viewModel = new RoomViewModel(room);
        
        return Json(viewModel);
    }

    [HttpPost("[action]")]
    public IActionResult Create(string game)
    {
        var roomName = Utils.RandomString(5);
        var data = (game, roomName);
        var exists = _roomRepository.Exists(data);
        if (exists)
            return Json(new { created = false });

        _roomRepository.Create(data, new Room(data));
        return Json(new {data.game, data.roomName });
    }

    [HttpPatch("[action]")]
    public IResult SetPassword(SetPasswordRequest data)
    {
        var (game, roomName, password) = data;
        var key = (game, roomName);
        var room = _roomRepository.Get(key);
        room.Password = password;
        _roomRepository.Update(key, room);

        return Results.Ok();
    }

    [HttpPatch("[action]")]
    public async Task<IResult> SetPoiType((string game, string roomName, string poiType) data)
    {
        var (game, roomName, poiType) = data;
        var key = (game, roomName);
        var room = _roomRepository.Get(key);
        room.PointOfInterestType = poiType;
        room.PointsOfInterest = _pointOfInterestRepository.Get((game, poiType)).ToList();
        _roomRepository.Update(key, room);

        await _roomHub.Clients.Group(game+roomName).PoiTypeChange(game, roomName, poiType);

        return Results.Ok();
    }
    
    [HttpGet("[action]/{game}/{roomName}")]
    public IActionResult GetPointsOfInterest(string game, string roomName)
    {
        var room = _roomRepository.Get((game, roomName));
        return Json(room.PointsOfInterest);
    }
}
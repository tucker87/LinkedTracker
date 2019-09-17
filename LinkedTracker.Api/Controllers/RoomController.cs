using Microsoft.AspNetCore.Mvc;
using LinkedTracker.Models;
using LinkedTracker.Data;
using Microsoft.AspNetCore.SignalR;
using LinkedTracker.Hubs;
using System.Threading.Tasks;

namespace LinkedTracker.Controllers
{
    [Route("[controller]")]
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IPointOfInterestRepository _pointOfInterestRepository;
        private readonly IHubContext<RoomHub, IRoomHub> _roomHub;

        public RoomController(IRoomRepository roomRepository, 
                              IPointOfInterestRepository pointOfInterestRepository, 
                              IHubContext<RoomHub, IRoomHub> roomHub)
        {
            _roomRepository = roomRepository;
            _pointOfInterestRepository = pointOfInterestRepository;
            _roomHub = roomHub;
        }

        [HttpGet("{game}/{roomName}")]
        public IActionResult ViewRoom(string game, string roomName)
        {
            var key = (game, roomName);
            var room = _roomRepository.GetOrCreate(key, () => new Room(key));

            var viewModel = new RoomViewModel(room);
            viewModel.PointsOfInterest = _pointOfInterestRepository.Get((game, room.PointOfInterestType));
            
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
        public IActionResult SetPassword((string game, string roomName, string password) data)
        {
            var (game, roomName, password) = data;
            var key = (game, roomName);
            var room = _roomRepository.Get(key);
            room.Password = password;
            _roomRepository.Update(key, room);

            return Json(new {set = true});
        }

        [HttpPatch("[action]")]
        public async Task<IActionResult> SetPoiType((string game, string roomName, string poiType) data)
        {
            var (game, roomName, poiType) = data;
            var key = (game, roomName);
            var room = _roomRepository.Get(key);
            room.PointOfInterestType = poiType;
            _roomRepository.Update(key, room);

            await _roomHub.Clients.All.PoiTypeChange(game, roomName, poiType);

            return Json(new {set = true});
        }
    }
}

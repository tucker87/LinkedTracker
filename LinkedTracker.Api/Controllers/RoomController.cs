using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LinkedTracker.Models;
using LinkedTracker.Data;

namespace LinkedTracker.Controllers
{
    [Route("[controller]")]
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet("{game}/{roomName}")]
        public IActionResult ViewRoom(string game, string roomName)
        {
            var key = (game, roomName);
            var room = _roomRepository.GetOrCreate(key, () => new Room(key));

            return Json(new RoomViewModel(room));
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

        [HttpPost("[action]")]
        public IActionResult SetPassword((string game, string roomName, string password) data)
        {
            var (game, roomName, password) = data;
            var key = (game, roomName);
            var room = _roomRepository.Get(key);
            room.Password = password;
            _roomRepository.Update(key, room);

            return Json(new {set = true});
        }
    }
}

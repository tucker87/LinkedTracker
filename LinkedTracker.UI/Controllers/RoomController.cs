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
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet("{game}/{roomName}")]
        public IActionResult Index(string game, string roomName)
        {
            var key = (game, roomName);
            var room = _roomRepository.GetOrCreate(key, () => new Room(key));
            
            var viewModel = new RoomViewModel(room);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create([FromBody]string game, [FromBody]string roomName)
        {
            var data = (game, roomName);
            var exists = _roomRepository.Exists(data);
            _roomRepository.Create(data, new Room(data));

            return Json(true);
        }

        [HttpPost]
        public IActionResult SetPassword((string game, string roomName, string password) data)
        {
            var (game, roomName, password) = data;
            var key = (game, roomName);
            var room = _roomRepository.Get(key);
            room.Password = password;
            _roomRepository.Update(key, room);

            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

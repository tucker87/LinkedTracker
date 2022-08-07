using System.Collections.Generic;
using LinkedTracker.Data.Models;

namespace LinkedTracker.Api.Models;

public class RoomViewModel
{
    public RoomViewModel(Room room)
    {
        Room = room;
    }

    public Room Room { get; set; }
}
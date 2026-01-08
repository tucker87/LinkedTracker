using LinkedTracker.Data.Models;

namespace LinkedTracker.Api.Models;

public class RoomViewModel(Room room)
{
   public Room Room { get; set; } = room;
}


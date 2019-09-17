using System.Collections.Generic;
using LinkedTracker.Data;

namespace LinkedTracker.Models
{
    public class RoomViewModel
    {
        public RoomViewModel(Room room)
        {
            Room = room;
        }

        public Room Room { get; set; }
        public List<PointOfInterest> PointsOfInterest { get; set; } = new List<PointOfInterest>();
    }
}
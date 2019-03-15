namespace LinkedTracker.Models
{
    public class RoomViewModel
    {
        public RoomViewModel(Room room)
        {
            Room = room;
        }
       public Room Room { get; set; }
    }
}
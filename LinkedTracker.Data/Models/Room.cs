public class Room 
{
     public Room((string game, string roomName) data)
    {
        Game = data.game;
        RoomName = data.roomName;
    }

        public string Game { get; set; }
        public string RoomName { get; set; }
        public string Password { get; set;}
}
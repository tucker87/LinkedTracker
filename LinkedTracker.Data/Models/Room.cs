using System.Collections.Generic;

namespace LinkedTracker.Data.Models;

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
    public string PointOfInterestType { get; set; }
    public List<PointOfInterest> PointsOfInterest { get; set; }
}
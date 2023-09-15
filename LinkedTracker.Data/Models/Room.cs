using System.Collections.Generic;

namespace LinkedTracker.Data.Models;

public class Room((string game, string roomName) data)
{
    public string Game { get; set; } = data.game;
    public string RoomName { get; set; } = data.roomName;
    public string Password { get; set;}
    public string PointOfInterestType { get; set; }
    public List<PointOfInterest> PointsOfInterest { get; set; }
}
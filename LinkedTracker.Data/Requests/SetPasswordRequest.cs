namespace LinkedTracker.Data.Requests;

public class SetPasswordRequest
{
    public string Game { get; set; }
    public string RoomName { get; set; }
    public string Password { get; set; }

    public void Deconstruct(out string game, out string roomName, out string password)
    {
        game = Game;
        roomName = RoomName;
        password = Password;
    }
}
using System.Threading.Tasks;
using LinkedTracker.Data;
using Microsoft.AspNetCore.SignalR;

namespace LinkedTracker.Api.Hubs;

public interface IRoomHub
{
    Task PoiTypeChange(string game, string room, string poiType);
    Task PoiDoneChange(int poiIndex, bool isDone);
}

public class RoomHub : Hub<IRoomHub>
{
    private readonly IRoomRepository _roomRepository;

    public RoomHub(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }
    
    public async Task SetPoiDone(string game, string roomName, int poiIndex, bool isDone)
    {
        var room = _roomRepository.Get((game, roomName));
        room.PointsOfInterest[poiIndex].IsDone = isDone;
        _roomRepository.Update((game, roomName), room);
        await Clients.Group($"{game}{roomName}").PoiDoneChange(poiIndex, isDone);
    }

    public async Task JoinRoom(string game, string roomName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"{game}{roomName}");
    }
}
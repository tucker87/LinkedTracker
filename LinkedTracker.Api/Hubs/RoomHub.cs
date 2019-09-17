using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace LinkedTracker.Hubs
{
    public interface IRoomHub
    {
        Task PoiTypeChange(string game, string room, string poiType);
    }

    public class RoomHub : Hub<IRoomHub>
    {
        public async Task Test()
        {
            
        }
    }
}
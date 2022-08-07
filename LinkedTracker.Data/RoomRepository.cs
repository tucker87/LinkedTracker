using LinkedTracker.Data.Models;

namespace LinkedTracker.Data;

public interface IRoomRepository : IRepository<(string game, string roomName), Room>
{
        
}
public class RoomRepository : Repository<(string, string), Room>, IRoomRepository
{
        
}
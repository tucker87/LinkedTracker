namespace LinkedTracker.Data
{
    public interface IRoomRepository : IRepository<(string, string), Room>
    {
        
    }
    public class RoomRepository : Repository<(string, string), Room>, IRoomRepository
    {
        
    }
}

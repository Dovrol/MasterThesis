namespace Infrastructure.MongoDB.Connection
{
    public interface IMongoConnection
    {
        string? GetConnectionString();
    }
}
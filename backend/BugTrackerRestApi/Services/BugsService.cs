using BugTrackerRestApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BugTrackerRestApi.Services;

public class BugsService
{
    private readonly IMongoCollection<Bug> _bugCollection;

    public BugsService(
        IOptions<BugTrackerDatabaseSettings> bugTrackerDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bugTrackerDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bugTrackerDatabaseSettings.Value.DatabaseName);
        
        _bugCollection = mongoDatabase.GetCollection<Bug>(
            bugTrackerDatabaseSettings.Value.BugsCollectionName);
    }

    public async Task<List<Bug>> GetAsync() =>
        await _bugCollection.Find(_ => true).ToListAsync();

    public async Task<Bug?> GetAsync(string id) =>
        await _bugCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Bug newBug) =>
        await _bugCollection.InsertOneAsync(newBug);

    public async Task UpdateAsync(string id, Bug updatedBug) =>
        await _bugCollection.ReplaceOneAsync(x => x.Id == id, updatedBug);

    public async Task RemoveAsync(string id) =>
        await _bugCollection.DeleteOneAsync(x => x.Id == id);
}
namespace BugTrackerRestApi.Models;

public class BugTrackerDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string BugsCollectionName { get; set; } = null!;
}
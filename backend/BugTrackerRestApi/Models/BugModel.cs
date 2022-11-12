using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace BugTrackerRestApi.Models;

public class Bug
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Title")]
    [JsonPropertyName("Title")]
    public string Title { get; set; }

    // [BsonElement("Severity")]
    public int Severity { get; set; }

    // [BsonElement("Timestamp")]
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
}


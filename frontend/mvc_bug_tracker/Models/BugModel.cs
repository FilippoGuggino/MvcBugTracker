// using System.ComponentModel.DataAnnotations;

namespace mvc_bug_tracker.Models;

public class Bug
{
    public string Id { get; set; }

    public string Title { get; set; }

    public int Severity { get; set; }

    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
}
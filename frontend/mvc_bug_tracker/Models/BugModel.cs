using System.ComponentModel.DataAnnotations;

namespace mvc_bug_tracker;

public class BugMode
{

    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    public int Severity { get; set; }

    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
}
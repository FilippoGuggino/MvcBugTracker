using System.ComponentModel.DataAnnotations;

namespace mvc_bug_tracker.Contracts.DTO
{
    public class UserLoginModel
    {
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
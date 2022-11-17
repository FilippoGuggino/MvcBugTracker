namespace mvc_bug_tracker.Contracts.DTO
{
    public class ChangePwdModel
    {
        public string CurrentPassword { get; set; }
        public string EmailAddress { get; set; }
        public string NewPassword { get; set; }
    }
}
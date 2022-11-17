namespace mvc_bug_tracker.Contracts.DTO
{
    public class ResetPasswordModel
    {
        public string UserId { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmationCode { get; set; }
        public string EmailAddress { get; set; }
    }
}
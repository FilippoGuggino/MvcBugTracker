namespace mvc_bug_tracker.Contracts.DTO
{
    public class InitForgotPwdResponse : BaseResponseModel
    {
        public string UserId { get; set; }
        public string EmailAddress { get; set; }
    }
}
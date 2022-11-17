namespace mvc_bug_tracker.Contracts.DTO
{
    public class AuthResponseModel : BaseResponseModel
    {
        public string EmailAddress { get; set; }
        public string UserId { get; set; }
        public TokenModel Tokens { get; set; }
    }
}
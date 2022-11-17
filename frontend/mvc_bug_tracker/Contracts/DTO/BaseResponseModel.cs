namespace mvc_bug_tracker.Contracts.DTO
{

    public class BaseResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public CognitoStatusCodes Status { get; set; }
    }
}
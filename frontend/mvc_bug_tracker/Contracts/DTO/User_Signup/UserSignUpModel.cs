namespace mvc_bug_tracker.Contracts.DTO
{
    public class UserSignUpModel
    {
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string GivenName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
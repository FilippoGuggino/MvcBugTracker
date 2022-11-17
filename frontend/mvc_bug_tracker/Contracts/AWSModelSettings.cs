namespace mvc_bug_tracker.Contracts
{
    public class AWS
    {
        public string Region { get; set; } = null!;

        public string UserPoolId { get; set; } = null!;

        public string AppClientId { get; set; } = null!;

        public string UserPoolClientId { get; set; } = null!;

        public string AppClientSecret { get; set; } = null!;
    }
}
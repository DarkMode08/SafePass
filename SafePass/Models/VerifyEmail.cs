namespace SafePass.Models
{
    public class VerifyEmail
    {
        public required string For { get; set; }

        public required string From { get; set; }

        public required string Content { get; set; }
    }
}

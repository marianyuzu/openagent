

namespace ContactUsApi.Models
{
    public class ContactSubmission
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Message { get; set; }
        public DateTime? SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}

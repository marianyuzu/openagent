namespace ContactUsApi.Models
{
    public class ContactInfo
    {
        public string? Header { get; set; }
        public string? Body { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Hours { get; set; }

        public string GetHeader() => Header ?? string.Empty;
        public string GetBody() => Body ?? string.Empty;
        public string GetPhone() => Phone ?? string.Empty;
        public string GetEmail() => Email ?? string.Empty;
        public string GetAddress() => Address ?? string.Empty;
        public string GetHours() => Hours ?? string.Empty;
    }
}

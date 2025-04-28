using AutoDetail.Core.Interfaces;

namespace AutoDetail.DAL.Models
{
    public class UserDb : IDatabaseEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PasswordHash { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsVerified { get; set; }
        public bool IsAdmin { get; set; }
        public string? PaymentDetail { get; set; }
        public AddressDb? Address { get; set; }
    }
}

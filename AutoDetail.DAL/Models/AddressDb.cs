using AutoDetail.Core.Interfaces;

namespace AutoDetail.DAL.Models
{
    public class AddressDb : IDatabaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Country { get; set; }
        public int Index { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Appartments { get; set; }
        public Guid? UserId { get; set; }
        public virtual UserDb User { get; set; }
    }
}

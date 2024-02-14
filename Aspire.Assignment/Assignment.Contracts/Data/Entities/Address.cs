using System.ComponentModel.DataAnnotations.Schema;
using Assignment.Contracts.Data.Entities.Identity;

namespace Assignment.Contracts.Data.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string? DoorNo { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string?  State { get; set; }
        public Guid UserId { get; set; }
        
        [ForeignKey("UserId")]
        public ApplicationUser? ApplicationUser { get; set;}
    }
}
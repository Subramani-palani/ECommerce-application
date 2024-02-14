namespace Assignment.Contracts.DTO
{
    public class UserResponseDTO
    {
        public Guid Id {get; set;}
        public string? PersonName { get; set; }
        public string? Email {get; set;}
        public string? PhoneNumber {get; set;}
    }
}
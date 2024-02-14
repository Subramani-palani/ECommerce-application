namespace Assignment.Contracts.DTO
{
    public class UserResponseDTO
    {
        public Guid UserId {get; set;}
        public string? PersonName { get; set; }
        public string? Email {get; set;}
        public string? PhoneNumber {get; set;}
        public string? Password {get;set;}
    }
}
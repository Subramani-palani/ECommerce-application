namespace Assignment.Contracts.DTO;

public class AuthenticationResponse
{
    public string? Token { get; set; }
    public string? PersonName { get; set; }
    public string? Email {get;set;}
}
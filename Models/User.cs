namespace JWTSimpleAuthentication.Models;

public record User(
    int Id,
    string Name,
    string Email,
    string Password,
    string[] Roles);

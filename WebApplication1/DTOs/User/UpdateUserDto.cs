namespace WebApplication1.DTOs.User;

public class UpdateUserDto
{
    [System.ComponentModel.DataAnnotations.Required]
    [System.ComponentModel.DataAnnotations.MinLength(3)]
    [System.ComponentModel.DataAnnotations.MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [System.ComponentModel.DataAnnotations.Required]
    [System.ComponentModel.DataAnnotations.EmailAddress]
    [System.ComponentModel.DataAnnotations.MaxLength(100)]
    public string Email { get; set; } = string.Empty;
}

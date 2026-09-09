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

    [System.ComponentModel.DataAnnotations.Required]
    [System.ComponentModel.DataAnnotations.MinLength(2)]
    [System.ComponentModel.DataAnnotations.MaxLength(100)]
    public string FullName { get; set; } = string.Empty;

    [System.ComponentModel.DataAnnotations.MaxLength(20)]
    public string? PhoneNumber { get; set; }

    [System.ComponentModel.DataAnnotations.MaxLength(250)]
    public string? Address { get; set; }

    [System.ComponentModel.DataAnnotations.MaxLength(500)]
    [System.ComponentModel.DataAnnotations.Url]
    public string? AvatarUrl { get; set; }
}

using Microsoft.AspNetCore.Mvc;

using WebApplication1.DTOs.User;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    // Dữ liệu giả chỉ tồn tại trong RAM và được tạo lại khi ứng dụng restart.
    // DTO trả về không chứa mật khẩu hoặc PasswordHash.
    private static readonly List<UserDto> FakeUsers =
    [
        new() { Id = 1, Username = "nguyenvana", Email = "ana@gmail.com", Role = "Buyer", IsActive = true, CreatedAt = DateTime.UtcNow.AddDays(-2) },
        new() { Id = 2, Username = "tranvanb", Email = "banb@gmail.com", Role = "Seller", IsActive = true, CreatedAt = DateTime.UtcNow.AddDays(-1) },
        new() { Id = 3, Username = "lethic", Email = "c.le@gmail.com", Role = "Buyer", IsActive = true, CreatedAt = DateTime.UtcNow.AddDays(-5) },
        new() { Id = 4, Username = "phamvand", Email = "d.pham@gmail.com", Role = "Seller", IsActive = true, CreatedAt = DateTime.UtcNow.AddDays(-4) },
        new() { Id = 5, Username = "hoangthie", Email = "e.hoang@gmail.com", Role = "Buyer", IsActive = true, CreatedAt = DateTime.UtcNow.AddDays(-3) },
        new() { Id = 6, Username = "vuminhf", Email = "f.vu@gmail.com", Role = "Seller", IsActive = true, CreatedAt = DateTime.UtcNow.AddDays(-2) },
        new() { Id = 7, Username = "dangthig", Email = "g.dang@gmail.com", Role = "Buyer", IsActive = true, CreatedAt = DateTime.UtcNow.AddDays(-1) }
    ];

    // HTTP GET api/users: trả về 200 OK cùng toàn bộ người dùng.
    [HttpGet]
    [ProducesResponseType(typeof(List<UserDto>), StatusCodes.Status200OK)]
    public ActionResult<List<UserDto>> GetAll() => Ok(FakeUsers);

    // HTTP GET api/users/1: model binding lấy id từ URL.
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<UserDto> GetById(int id)
    {
        var user = FakeUsers.FirstOrDefault(item => item.Id == id);
        return user is null
            ? NotFound(new { message = $"Không tìm thấy người dùng có Id = {id}." })
            : Ok(user);
    }

    // HTTP PUT api/users/1: đọc dữ liệu cập nhật từ JSON body.
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public ActionResult<UserDto> Update(int id, [FromBody] UpdateUserDto request)
    {
        var user = FakeUsers.FirstOrDefault(item => item.Id == id);
        if (user is null)
            return NotFound(new { message = $"Không tìm thấy người dùng có Id = {id}." });

        var username = request.Username.Trim();
        var email = request.Email.Trim().ToLowerInvariant();
        if (FakeUsers.Any(item => item.Id != id &&
                                  (item.Username.Equals(username, StringComparison.OrdinalIgnoreCase) ||
                                   item.Email.Equals(email, StringComparison.OrdinalIgnoreCase))))
        {
            return Conflict(new { message = "Tên đăng nhập hoặc email đã được sử dụng." });
        }

        user.Username = username;
        user.Email = email;
        user.UpdatedAt = DateTime.UtcNow;
        return Ok(user);
    }

    // HTTP DELETE api/users/1: soft delete bằng cách khóa tài khoản.
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Deactivate(int id)
    {
        var user = FakeUsers.FirstOrDefault(item => item.Id == id);
        if (user is null)
            return NotFound(new { message = $"Không tìm thấy người dùng có Id = {id}." });

        user.IsActive = false;
        user.UpdatedAt = DateTime.UtcNow;
        return NoContent();
    }
}

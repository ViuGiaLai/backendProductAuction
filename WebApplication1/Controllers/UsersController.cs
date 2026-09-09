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
        new() { Id = 1, Username = "nguyenvana", FullName = "Nguyễn Văn An", Email = "ana@gmail.com", PhoneNumber = "0901000001", Address = "Hà Nội", Role = "Buyer", IsActive = true, CreatedAt = DateTime.UtcNow.AddDays(-2) },
        new() { Id = 2, Username = "tranvanb", FullName = "Trần Văn Bình", Email = "banb@gmail.com", PhoneNumber = "0901000002", Address = "Đà Nẵng", Role = "Seller", IsActive = true, CreatedAt = DateTime.UtcNow.AddDays(-1) },
        new() { Id = 3, Username = "lethic", FullName = "Lê Thị Chi", Email = "c.le@gmail.com", PhoneNumber = "0901000003", Address = "Hải Phòng", Role = "Buyer", IsActive = true, CreatedAt = DateTime.UtcNow.AddDays(-5) },
        new() { Id = 4, Username = "phamvand", FullName = "Phạm Văn Dũng", Email = "d.pham@gmail.com", PhoneNumber = "0901000004", Address = "Hồ Chí Minh", Role = "Seller", IsActive = true, CreatedAt = DateTime.UtcNow.AddDays(-4) },
        new() { Id = 5, Username = "hoangthie", FullName = "Hoàng Thị Em", Email = "e.hoang@gmail.com", PhoneNumber = "0901000005", Address = "Quảng Ninh", Role = "Buyer", IsActive = true, CreatedAt = DateTime.UtcNow.AddDays(-3) },
        new() { Id = 6, Username = "vuminhf", FullName = "Vũ Minh Phúc", Email = "f.vu@gmail.com", PhoneNumber = "0901000006", Address = "Cần Thơ", Role = "Seller", IsActive = true, CreatedAt = DateTime.UtcNow.AddDays(-2) },
        new() { Id = 7, Username = "dangthig", FullName = "Đặng Thị Giang", Email = "g.dang@gmail.com", PhoneNumber = "0901000007", Address = "Nha Trang", Role = "Buyer", IsActive = true, CreatedAt = DateTime.UtcNow.AddDays(-1) }
    ];

    // HTTP GET api/users?search=nguyen: tìm theo họ tên hoặc username.
    // Nếu bỏ search, API trả về toàn bộ người dùng.
    [HttpGet]
    [ProducesResponseType(typeof(List<UserDto>), StatusCodes.Status200OK)]
    public ActionResult<List<UserDto>> GetAll([FromQuery] string? search = null)
    {
        var users = string.IsNullOrWhiteSpace(search)
            ? FakeUsers
            : FakeUsers
                .Where(item => item.FullName.Contains(search.Trim(), StringComparison.OrdinalIgnoreCase) ||
                               item.Username.Contains(search.Trim(), StringComparison.OrdinalIgnoreCase))
                .ToList();

        return Ok(users);
    }

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
        user.FullName = request.FullName.Trim();
        user.PhoneNumber = request.PhoneNumber?.Trim() ?? string.Empty;
        user.Address = request.Address?.Trim() ?? string.Empty;
        user.AvatarUrl = string.IsNullOrWhiteSpace(request.AvatarUrl) ? null : request.AvatarUrl.Trim();
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

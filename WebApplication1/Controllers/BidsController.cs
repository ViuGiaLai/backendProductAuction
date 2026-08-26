using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Bid;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BidsController : ControllerBase
{
    [HttpPost]
    public IActionResult PlaceBid([FromBody] CreateBidDto request)
    {
        return Ok(new { Message = "Bid placed successfully" });
    }

    [HttpGet("auction/{auctionId}")]
    public IActionResult GetBidsByAuction(int auctionId)
    {
        return Ok(new object[] { });
    }
}

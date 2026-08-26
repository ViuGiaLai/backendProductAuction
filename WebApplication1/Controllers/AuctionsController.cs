using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Auction;
using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuctionsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<AuctionDto>> GetAll()
    {
        return Ok(new List<AuctionDto>());
    }

    [HttpGet("{id}")]
    public ActionResult<AuctionDto> GetById(int id)
    {
        return Ok(new AuctionDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateAuctionDto request)
    {
        return CreatedAtAction(nameof(GetById), new { id = 1 }, request);
    }
}

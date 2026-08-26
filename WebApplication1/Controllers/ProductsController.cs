using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Product;
using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<ProductDto>> GetAll()
    {
        return Ok(new List<ProductDto>());
    }

    [HttpGet("{id}")]
    public ActionResult<ProductDto> GetById(int id)
    {
        return Ok(new ProductDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateProductDto request)
    {
        return CreatedAtAction(nameof(GetById), new { id = 1 }, request);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateProductDto request)
    {
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGStoreWebAPI.Models.Abstract;
using VGStoreWebAPI.Models.Entities;

namespace VGStoreWebAPI.Controllers
{
  [ApiController]
  [Produces("application/Json")]
  [Route("api/product")]
  public class ProductController : ControllerBase
  {
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }
    [HttpGet, Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Product>))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public IActionResult Get()
    {
      var products = _productRepository.GetProducts();
      if (products != null)
      {
        return Ok(products);
      }
      return NoContent();
    }

    [HttpGet, Route("id/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Product>))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Get(int id)
    {
      var product = _productRepository.GetProductbyId(id);
      if (product != null)
      {
        return Ok(product);
      }
      return NoContent();
    }

    [HttpPost, Route("")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Product))]
    public IActionResult Post([FromBody] Product product)
    {
      var newProduct = _productRepository.AddProduct(product);
      if (newProduct != null)
      {
        return Ok(product);
      }
      return BadRequest($"New Product could not be created.....");
    }

    [HttpPut, Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    public IActionResult Put([FromBody] Product product)
    {
      var updateProduct = _productRepository.UpdateProduct(product);
      if (updateProduct != null)
      {
        return Ok(product);
      }
      return BadRequest($"Could not update the Product.....");
    }

    [HttpDelete, Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    public IActionResult Delete(long id)
    {
      bool flag = _productRepository.DeleteProduct(id);
      if (flag)
      {
        return Ok($"Product with the Id: '{id}' deleted successfully");
      }
      return NotFound($"No product found with the Id : '{id}'");
    }
  }
}

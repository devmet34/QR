using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;

namespace Api.Controllers
{
  [Route("api/")]
  [ApiController]
  public class ExtApiController : ControllerBase
  {
    private readonly IExtApiIntegration _extApiIntegration;

    public ExtApiController(IExtApiIntegration extApiIntegration)
    {
      _extApiIntegration = extApiIntegration;
    }

    [HttpGet("products/external/{id}")]
    public async Task<IActionResult> GetExtProduct(int id)
    {
     var product = await _extApiIntegration.GetExtProductAsync(id);
      if (product == null)
      {
        return NotFound($"Product with ID {id} not found.");
      }
      return Ok(product);
    }
  }
}

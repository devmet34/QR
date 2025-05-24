using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class QrCodeController : ControllerBase
  {
    [HttpGet("getcodes")]
    public IActionResult GetCodes()
    {
      // This is a placeholder for the actual implementation.
      // You would typically retrieve the QR codes from a database or service.
      var qrCodes = new List<string> { "QR1234567890", "QR0987654321" };
      return Ok(qrCodes);
    }

    [HttpGet("getcodeid")]
    public IActionResult GetCodeId(int id)
    {
      // This is a placeholder for the actual implementation.
      // You would typically retrieve the QR code by ID from a database or service.
      var qrCode = $"QRCode with ID: {id}";
      return Ok(qrCode);
    }

    [HttpPost("createcode")]
    public IActionResult CreateCode([FromServices] IGs1 gs1)
    {
      var code=gs1.GenerateUniqueGs1Code();
      // Simulate saving the QR code
      var createdQrCode = $"Created QR Code: ";
      return CreatedAtAction(nameof(GetCodeId),code);
    }
  }
}

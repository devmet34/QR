using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  [Route("api/")]
  [ApiController]
  public class QrCodeController : ControllerBase
  {

    private readonly IQrCodeService _qrCodeService;

    public QrCodeController(IQrCodeService qrCodeService)
    {
      _qrCodeService = qrCodeService;
    }

    [HttpGet("codes")]
    public async Task<IActionResult> GetCodes()
    {
      var codes = await _qrCodeService.GetAllQrCodesAsync();
      if (codes == null)
        return NotFound();
      return Ok(codes);
    }

    [HttpGet("codes/{id}")]
    public async Task<IActionResult> GetCodeId(int id)
    {
      var code = await _qrCodeService.GetQrCodeByIdAsync(id);
      if (code == null)
        return NotFound();
      return Ok(code);
    }

    [HttpPost("validate/{code}")]
    public  IActionResult ValidateCode(string code)
    {
      if (string.IsNullOrEmpty(code))
      {
        return BadRequest("Code cannot be null or empty.");
      }
      if (code.Length != 12)
      {
        return BadRequest("Code must be exactly 12 characters long.");
      }
      if (!long.TryParse(code,out long n) )
        return BadRequest("Code must be numeric.");

      var isValid = _qrCodeService.IsQrCodeValid(code);
      if (!isValid)      
        return NotFound("Invalid QR code.");
      
      return Ok("QR code is valid.");
    }

    [HttpPost("codes")]
    public async Task<IActionResult> CreateCode()
    {
      var code = await _qrCodeService.CreateAddQrCodeAsync();
      if (code == null)
      {
        return NoContent();
      }

      return Ok(code);
    }
  }
}

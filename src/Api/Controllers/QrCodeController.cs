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

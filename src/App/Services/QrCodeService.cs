using Core.Entities;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace App.Services
{
  public class QrCodeService : Core.Interfaces.IQrCodeService
  {
    //private readonly Gs1 _gs1 = new Gs1();
    private readonly Gs1 _gs1;
    private readonly IRepoQrCode _repoQrCode;
    private readonly ILogger<QrCodeService> _logger;
    public QrCodeService(IRepoQrCode repoQrCode, ILogger<QrCodeService> logger, Gs1 gs1)
    {
      _repoQrCode = repoQrCode ?? throw new ArgumentNullException(nameof(repoQrCode));
      _logger = logger;
      _gs1 = gs1;
    }

    public async Task<QrCode?> CreateAddQrCodeAsync()
    {
      try
      {
        var gs1Code = _gs1.GenerateGs1Code();
        var qrCode = new QrCode(gs1Code);
        await _repoQrCode.AddQrCodeAsync(qrCode);
        return qrCode;
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.Message);
        return null;
      }
    }

    public async Task<IEnumerable<QrCode>?> GetAllQrCodesAsync()
    {
      return await _repoQrCode.GetAllQrCodesAsync();
    }

    public async Task<QrCode?> GetQrCodeByIdAsync(int id)
    {
      return await _repoQrCode.GetQrCodeByIdAsync(id);
    }

    public bool IsQrCodeValid(string code)
    {
      if (string.IsNullOrEmpty(code) || code.Length != 12)
      {
        return false;
      }
      return _gs1.IsValidGs1Code(code);
    }
  }
}

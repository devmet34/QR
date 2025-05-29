using Core.Entities;
using Core.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace App.Services
{
  public class QrCodeService : Core.Interfaces.IQrCodeService
  {
    private readonly Gs1 _gs1;
    private readonly IRepoQrCode _repoQrCode;
    private readonly ILogger<QrCodeService> _logger;
    private readonly IConfiguration _config;
    public QrCodeService(IRepoQrCode repoQrCode, ILogger<QrCodeService> logger, Gs1 gs1, IConfiguration config)
    {
      _repoQrCode = repoQrCode ?? throw new ArgumentNullException(nameof(repoQrCode));
      _logger = logger;
      _gs1 = gs1;
      _config = config;
    }

    public async Task<QrCode?> CreateAddQrCodeAsync()
    {
      int maxRetries = int.TryParse(_config["Qrcode:MaxRetries"], out int n) ? n : 3;
      int i = 0;

      while (i <= maxRetries)
      {
        try
        {
          var gs1Code = _gs1.GenerateGs1Code();
          var qrCode = new QrCode(gs1Code);
          await _repoQrCode.AddQrCodeAsync(qrCode);
          //await AddQrCodeAsync(qrCode);
          return qrCode;
        }

        catch (DbUpdateException ex) when (ex.InnerException is SqlException inner && inner.Number == 2601) //mc, db duplicate error try again 
        {
          i++;
          if (i >= maxRetries)
            throw;
          continue;
        }

        catch (Exception ex)
        {
          _logger.LogError(ex.Message);
          throw;
        }
      }
      return null;
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

using Core.Entities;
using Core.Interfaces;
using Infra;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
  public class RepoQrCode : IRepoQrCode
  {
    private readonly QrDbContext _qrDbContext;
    public RepoQrCode(QrDbContext qrDbContext)
    {
      _qrDbContext = qrDbContext ?? throw new ArgumentNullException(nameof(qrDbContext));
    }

    private async Task SaveChangesAsync()
    {
      await _qrDbContext.SaveChangesAsync();
    } 
    public async Task AddQrCodeAsync(QrCode qrCode)
    {
      await _qrDbContext.QrCodes.AddAsync(qrCode);
      await SaveChangesAsync();
    }

    public async Task<IEnumerable<QrCode>?> GetAllQrCodesAsync()
    {
      return await _qrDbContext.QrCodes.AsNoTracking().ToListAsync();
    }

    public async Task<QrCode?> GetQrCodeByIdAsync(int id)
    {
      return await _qrDbContext.QrCodes.AsNoTracking().Where(q => q.Id == id).FirstOrDefaultAsync();
    }
  }
}

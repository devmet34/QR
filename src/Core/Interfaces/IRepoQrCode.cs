using Core.Entities;

namespace Core.Interfaces
{
  public interface IRepoQrCode
  {
    public Task<IEnumerable<QrCode>?> GetAllQrCodesAsync();
    public Task<QrCode?> GetQrCodeByIdAsync(int id);
    public Task AddQrCodeAsync(QrCode qrCode);

  }
}

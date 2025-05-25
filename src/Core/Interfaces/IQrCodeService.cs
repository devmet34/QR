using Core.Entities;

namespace Core.Interfaces
{

  public interface IQrCodeService
  {
    public Task<IEnumerable<QrCode>?> GetAllQrCodesAsync();
    public Task<QrCode?> GetQrCodeByIdAsync(int id);
    public Task<QrCode?> CreateAddQrCodeAsync();
  }
}

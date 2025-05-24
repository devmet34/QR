using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
  public class QrCode
  {

    public int Id { get; private set; }
    public string Code { get; private set; }

    public QrCode(string code)
    {
      if (string.IsNullOrEmpty(code) || code.Length > Constants.QrCodeLen)
      {
        throw new ArgumentException($"Invalid QR code. It must be non-empty and up to {Constants.QrCodeLen} characters long.", nameof(code));
      }

      Code = code;
    }



  }
}

using Core.Interfaces;
using System.Security.Cryptography;

namespace App.Services
{
  public class Gs1 : IGs1
  {
    public string GenerateUniqueGs1Code() => RandomNumberGenerator.GetString("0123456789", 11);




  }
}

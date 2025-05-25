using System.Security.Cryptography;

namespace App
{
  public class Gs1
  {

    /// <summary>
    /// mc, Generates a random GS1 code (12 digits) with a check digit.
    /// </summary>
    /// <returns></returns>
    public string GenerateGs1Code() 
    {
      string checkDigit;
      int sum = 0;
      bool is3 = true;
      var randomStr = RandomNumberGenerator.GetString("0123456789", 11);
      foreach (var c in randomStr)
      {
        int n = int.Parse(c.ToString());
        if (is3)
          sum += n * 3;
        else
          sum += n;
        is3 = !is3;
      }
      if (sum % 10 == 0)
        checkDigit = "0";
      else
        checkDigit = (10 - sum % 10).ToString();

      return randomStr+=checkDigit;
    }

    /// <summary>
    /// mc, Validates a GS1 code (12 digits) by checking the check digit.
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public bool IsValidGs1Code(string code)
    {
      if (string.IsNullOrEmpty(code) || code.Length != 12)
        return false;
      int sum = 0;
      bool is3 = true;
      for (int i = 0; i < code.Length - 1; i++)
      {
        int n = int.Parse(code[i].ToString());
        if (is3)
          sum += n * 3;
        else
          sum += n;
        is3 = !is3;
      }
      int checkDigit = int.Parse(code[11].ToString());
      return (sum + checkDigit) % 10 == 0;
    }


  }
}

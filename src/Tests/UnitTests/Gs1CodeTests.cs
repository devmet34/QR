using Xunit;


namespace Tests.UnitTests
{
  public class Gs1CodeTests
  {

    [Fact]
    public void GenerateGs1Code_ShouldReturnValidCode()
    {
      var gs1 = new App.Gs1();
      string code = gs1.GenerateGs1Code();
      Assert.NotNull(code);
      Assert.Equal(12, code.Length);
      Assert.True(gs1.IsValidGs1Code(code));
    }

    [Fact]
    public void IsValidGs1Code()
    {
      var gs1 = new App.Gs1();
      string validCode = "123456789012"; // Example valid GS1 code
      string validCode2 = "023456789107"; // Example valid GS1 code
      string invalidCode = "123456789016"; // Example invalid GS1 code
      string invalidCode2 = "123456789011"; // Example invalid GS1 code
      string invalidCode3 = "123456789015"; // Example invalid GS1 code
      Assert.True(gs1.IsValidGs1Code(validCode));
      Assert.True(gs1.IsValidGs1Code(validCode2));
      Assert.False(gs1.IsValidGs1Code(invalidCode));
      Assert.False(gs1.IsValidGs1Code(invalidCode2));
      Assert.False(gs1.IsValidGs1Code(invalidCode3));
      Assert.False(gs1.IsValidGs1Code("")); // Empty code
      Assert.False(gs1.IsValidGs1Code("1234567890")); // Too short
      Assert.False(gs1.IsValidGs1Code("1234567890123")); // Too long

    }


  }
}

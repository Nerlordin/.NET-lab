using System.Globalization;

namespace Owoce.Test
{
    public class UnitTest1
    {
      [Fact]
public void
FormatUsdPrice_ProperFormat_ShouldReturnProperString()
{
var data = 0.05;          
var culture = CultureInfo.GetCultureInfo("en-US");
var expected = data.ToString("C", culture);
var result = MyFormatter.FormatUsdPrice(data);
Assert.StartsWith("$", result);
Assert.Contains(".", result);

Assert.Equal(expected, result);
}

    }
}
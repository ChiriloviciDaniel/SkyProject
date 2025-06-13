using System.Globalization;
namespace SkyProject.Utils;
internal static class GlobalizationUtils
{
    public static void ConfigureCurrentCulture()
    {
        var cultureInfo = new CultureInfo("ro-RO");
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
    }
}
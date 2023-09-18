using System.Globalization;

namespace StellarisTechTree.Domain.Extensions;

public static class ObjectExtensions
{
    public static decimal ToDecimal(this object source)
    {
        if (source is decimal decimalValue)
        {
            return decimalValue;
        }

        var numberFormat = new NumberFormatInfo
        {
            NumberDecimalSeparator = ".",
            NegativeSign = "-"
        };
        return decimal.TryParse(source.ToString(), NumberStyles.Any, numberFormat, out decimalValue) ? decimalValue : 0;
    }
}
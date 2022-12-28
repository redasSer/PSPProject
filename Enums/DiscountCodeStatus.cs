using System.Text.Json.Serialization;

namespace PSP.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DiscountCodeStatus
{
    VALUE,
    PERCENTAGE,
    DISABLED
}
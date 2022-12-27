using System.Text.Json.Serialization;

namespace PSP.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderStatus
{
    RESERVED,
    OPENED,
    CANCELLED,
    CLOSED
}
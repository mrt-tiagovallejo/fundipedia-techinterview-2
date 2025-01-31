using System.Text.Json.Serialization;

namespace Fundipedia.TechInterview.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderType
{
    Repair,
    Hire,
}

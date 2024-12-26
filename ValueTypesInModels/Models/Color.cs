using System.Text.Json.Serialization;

namespace ValueTypesInModels.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Color
{
    Red,
    Green,
    Blue
}

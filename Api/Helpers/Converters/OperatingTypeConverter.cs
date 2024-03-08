using System.Text.Json;
using System.Text.Json.Serialization;
using DeLijn.Net.Entities.Enums;

namespace DeLijn.Net.Helpers.Converters;

internal class OperatingTypeConverter : JsonConverter<OperatingType>
{
    public override OperatingType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.GetString() switch
        {
            "BELBUS" => OperatingType.BellBus,
            "FABRIEKSLIJN" => OperatingType.FactoryLine,
            "NACHTLIJN" => OperatingType.NightLine,
            "NORMAAL" => OperatingType.Normal,
            "SCHOOLBUS" => OperatingType.SchoolBus,
            "SNELDIENST" => OperatingType.ExpressService,
            "TECHNISCHE_LIJN" => OperatingType.TechnicalLine,
            _ => OperatingType.Unknown
        };

    public override void Write(Utf8JsonWriter writer, OperatingType value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value switch
        {
            OperatingType.BellBus => "BELBUS",
            OperatingType.FactoryLine => "FABRIEKSLIJN",
            OperatingType.NightLine => "NACHTLIJN",
            OperatingType.Normal => "NORMAAL",
            OperatingType.SchoolBus => "SCHOOLBUS",
            OperatingType.ExpressService => "SNELDIENST",
            OperatingType.TechnicalLine => "TECHNISCHE_LIJN",
            _ => string.Empty,
        });
}
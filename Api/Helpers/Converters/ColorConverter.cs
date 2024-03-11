using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DeLijn.Net.Helpers.Converters;

internal class ColorConverter : JsonConverter<Color>
{
    public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        (short r, short g, short b) rgb = new();

        for (int i = 0; i < 3; i++)
        {
            reader.Read();

            switch (i)
            {
                case 0:
                    rgb.r = reader.GetInt16();
                    break;
                case 1:
                    rgb.g = reader.GetInt16();
                    break;
                case 2:
                    rgb.b = reader.GetInt16();
                    break;
            }
        }

        return Color.FromArgb(rgb.r, rgb.g, rgb.b);
    }

    public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options) =>
        writer.WriteStringValue("");
}
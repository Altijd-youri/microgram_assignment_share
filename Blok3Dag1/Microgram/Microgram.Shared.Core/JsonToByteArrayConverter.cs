using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microgram.Backend.Core;

/**
 * https://stackoverflow.com/questions/61565947/the-json-value-could-not-be-converted-to-system-byte#answer-72672927
 */
internal sealed class JsonToByteArrayConverter : JsonConverter<byte[]?>
{
    // Converts base64 encoded string to byte[].
    public override byte[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (!reader.TryGetBytesFromBase64(out byte[]? result) || result == default)
        {
            throw new ArgumentException("Image data invalid.");
        }
        return result;
    }

    // Converts byte[] to base64 encoded string.
    public override void Write(Utf8JsonWriter writer, byte[]? value, JsonSerializerOptions options)
    {
        writer.WriteBase64StringValue(value);
    }
}
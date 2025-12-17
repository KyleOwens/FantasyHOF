using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FantasyHOF.ESPN.Enums
{
    public class JsonNumberEnumConverter<TEnum> : JsonConverter<TEnum> where TEnum : struct, Enum
    {
        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt32(out var intValue))
                return (TEnum)Enum.ToObject(typeof(TEnum), intValue);

            if (reader.TokenType == JsonTokenType.String && int.TryParse(reader.GetString(), out intValue))
                return (TEnum)Enum.ToObject(typeof(TEnum), intValue);

            throw new JsonException($"Cannot convert {reader.GetString()} to {typeof(TEnum)}");
        }

        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(Convert.ToInt32(value));
        }
    }
}

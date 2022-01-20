using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondVKBanner.Converters
{
    class StringArrayOrStringToArrayJsonConverter : JsonConverter
    {
        const bool DISCINT_SAME_PICTURES = false;

        public override bool CanConvert(Type objectType) => objectType == typeof(string) || objectType.IsAssignableFrom(typeof(IEnumerable<string>));

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String) return new string[] { reader.Value as string };
            if (reader.TokenType == JsonToken.StartArray) return DISCINT_SAME_PICTURES ? serializer.Deserialize<string[]>(reader).Distinct().ToArray() : serializer.Deserialize<string[]>(reader);
            throw new NotImplementedException();
            //return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is string) writer.WriteValue(value);
            else if (value is IEnumerable<string>) serializer.Serialize(writer, value);
            else throw new NotImplementedException();
        }
    }
}
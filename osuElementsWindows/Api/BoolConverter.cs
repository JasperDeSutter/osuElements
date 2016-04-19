using System;
using Newtonsoft.Json;
using osuElements.Storyboards.Triggers;

namespace osuElements.Api
{
    internal class BoolConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            writer.WriteValue(((bool)value) ? 1 : 0);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            int value;
            if (!int.TryParse(reader.Value.ToString(), out value)) throw new ArgumentException("value was not an int for bool conversion");
            switch (value) {
                case 1:
                    return true;
                case 0:
                    return false;
                default:
                    throw new InvalidCastException("Value was not 0 or 1 for bool conversion");
            }
        }

        public override bool CanConvert(Type objectType) {
            return objectType == typeof(bool);
        }
    }
}
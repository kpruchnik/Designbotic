using Designbotic.JSON.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Designbotic.JSON.Core.Utilities
{
    internal class MaterialEnumConverter : JsonConverter<MaterialEnum>
    {
        public override MaterialEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                string enumString = reader.GetString();
                if (Enum.TryParse(enumString, true, out MaterialEnum category))
                    return category;
            }

            return MaterialEnum.Unknow;
        }

        public override void Write(Utf8JsonWriter writer, MaterialEnum value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}

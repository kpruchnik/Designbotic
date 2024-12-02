using Designbotic.JSON.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Designbotic.JSON.Core.Utilities
{
    internal class CategoryEnumConverter : JsonConverter<CategoryEnum>
    {
        public override CategoryEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                string enumString = reader.GetString();
                if (Enum.TryParse(enumString, true, out CategoryEnum category))
                    return category;
            }

            return CategoryEnum.Unknow;
        }

        public override void Write(Utf8JsonWriter writer, CategoryEnum value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}

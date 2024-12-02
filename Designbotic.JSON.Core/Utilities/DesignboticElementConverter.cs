using Designbotic.JSON.Core.Models.Enums;
using Designbotic.JSON.Core.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Designbotic.JSON.Core.Utilities
{
    public class DesignboticElementConverter : JsonConverter<DesignboticElement>
    {
        public override DesignboticElement Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                JsonElement root = doc.RootElement;

                int id = root.GetProperty(nameof(DesignboticElement.Id)).GetInt32();
                string name = root.GetProperty(nameof(DesignboticElement.Name)).GetString();
                CategoryEnum category = (CategoryEnum)Enum.Parse(typeof(CategoryEnum), root.GetProperty(nameof(DesignboticElement.Category)).GetString(), true);
                List<MaterialEnum> materials = root.GetProperty(nameof(DesignboticElement.Materials)).EnumerateArray()
                    .Select(m => (MaterialEnum)Enum.Parse(typeof(MaterialEnum), m.GetString(), true)).ToList();

                return new DesignboticElement(id, name, category, materials);
            }
        }

        public override void Write(Utf8JsonWriter writer, DesignboticElement value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteNumber("Id", value.Id);
            writer.WriteString("Name", value.Name);
            writer.WriteString("Category", value.Category.ToString());
            writer.WriteStartArray("Materials");
            foreach (var material in value.Materials)
            {
                writer.WriteStringValue(material.ToString());
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
    }
}

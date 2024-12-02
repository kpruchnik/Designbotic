using System.Text.Json;
using Designbotic.JSON.Core.Models;
using Designbotic.JSON.Core.Models.Enums;
using System.Text.Json.Serialization;

namespace Designbotic.JSON.Core.Utilities
{
    public static class DElementSerializers
    {
        private static readonly JsonSerializerOptions _writeOptions = new JsonSerializerOptions
        {
            Converters =
            {
                //new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, false),
                new CategoryEnumConverter(),
                new MaterialEnumConverter(),
                new DesignboticElementConverter()
            },
            PropertyNameCaseInsensitive = true
        };

        private static readonly JsonSerializerOptions _readOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            IncludeFields = true,
            RespectRequiredConstructorParameters = true,
            Converters =
            {
                new CategoryEnumConverter(),
                new MaterialEnumConverter(),
                new DesignboticElementConverter()
            }
        };

        public static DesignboticElement Deserialize(string json)
        {
            var element = JsonSerializer.Deserialize<DesignboticElement>(json, _readOptions);
            return element ?? new DesignboticElement(0, string.Empty, CategoryEnum.Unknow, new List<MaterialEnum>() { MaterialEnum.Unknow});
        }

        public static DesignboticElement[] DeserializeArray(string json)
        {
            var elements = JsonSerializer.Deserialize<DesignboticElement[]>(json, _writeOptions);

            foreach (var element in elements)
            {
                if (element.Materials == null)
                    element.Materials = new List<MaterialEnum>() { MaterialEnum.Unknow };
            }

            return elements ?? Array.Empty<DesignboticElement>();
        }

        public static string SerializeElements(IEnumerable<DesignboticElement> elements)
        {
            return JsonSerializer.Serialize(elements, _writeOptions);
        }
    }
}

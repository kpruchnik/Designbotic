using Designbotic.JSON.Core.Models.Enums;
using System.Text.Json.Serialization;

namespace Designbotic.JSON.Core.Models
{
    public class DesignboticElement
    {
        #region FIELDS AND PARAMETERS

        public List<MaterialEnum> Materials { get; internal set; }
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public CategoryEnum Category { get; internal set; }

        #endregion

        #region CONSTRUCTORS

        [JsonConstructor]
        public DesignboticElement(int id, string name, CategoryEnum category, List<MaterialEnum> materials)
        {
            Id = id;
            Name = name;
            Category = category;
            Materials = materials;
            Category = category;
        }

        #endregion

    }
}

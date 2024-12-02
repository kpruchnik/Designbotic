using Designbotic.JSON.Core.Models.Enums;
using Designbotic.JSON.Core.Models;
using Designbotic.JSON.Core.Utilities;

namespace Designbotic.JSON.Core.Tests
{
    public class SerializersTests
    {
        [Fact]
        public void Deserialize_ShouldReturnDesignboticElement_WhenJsonIsValid()
        {
            // Arrange
            string json = "{\"id\":1,\"name\":\"Element1\",\"category\":\"Wall\",\"materials\":[\"Plaster\",\"Brick\"]}";

            // Act
            var result = DElementSerializers.Deserialize(json);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Element1", result.Name);
            Assert.Equal(CategoryEnum.Wall, result.Category);
            Assert.Contains(MaterialEnum.Plaster, result.Materials);
            Assert.Contains(MaterialEnum.Brick, result.Materials);
        }

        [Fact]
        public void Deserialize_ShouldReturnDefaultElement_WhenJsonIsInvalid()
        {
            // Arrange
            string json = "{\"Id\":1,\"Name\":\"Element1\",\"Category\":\"InvalidCategory\",\"Materials\":[\"Plaster\",\"Brick\"]}";
            //string json = "{\"id\":1,\"name\":\"Element1\"}";

            // Act
            var result = DElementSerializers.Deserialize(json);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Element1", result.Name);
            Assert.Equal(CategoryEnum.Unknow, result.Category);
        }

        [Fact]
        public void DeserializeArray_ShouldReturnArrayOfElements_WhenJsonIsValid()
        {
            // Arrange
            string json = "[{\"id\":1,\"name\":\"Element1\",\"category\":\"Wall\"},{\"id\":2,\"name\":\"Element2\",\"category\":\"Floor\"}]";

            // Act
            var result = DElementSerializers.DeserializeArray(json);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Length);
            Assert.Equal(1, result[0].Id);
            Assert.Equal("Element1", result[0].Name);
            Assert.Equal(CategoryEnum.Wall, result[0].Category);
            Assert.Equal(2, result[1].Id);
            Assert.Equal("Element2", result[1].Name);
            Assert.Equal(CategoryEnum.Floor, result[1].Category);
        }

        [Fact]
        public void DeserializeArray()
        {
            // Arrange
            string json = "[{\"id\":1,\"name\":\"Element1\",\"category\":\"InvalidCategory\"}]";

            // Act
            var result = DElementSerializers.DeserializeArray(json);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void SerializeElements_ShouldReturnJsonString_WhenElementsAreValid()
        {
            // Arrange
            var elements = new List<DesignboticElement>
        {
            new DesignboticElement(1, "Element1", CategoryEnum.Wall, new List<MaterialEnum>() { MaterialEnum.Plaster, MaterialEnum.Brick }),
            new DesignboticElement(2, "Element2", CategoryEnum.Floor, new List<MaterialEnum>() { MaterialEnum.Concrete })
        };

            // Act
            var json = DElementSerializers.SerializeElements(elements);

            // Assert
            Assert.NotNull(json);
            Assert.Contains("\"Id\":1", json);
            Assert.Contains("\"Name\":\"Element1\"", json);
            Assert.Contains("\"Category\":\"Wall\"", json);
            Assert.Contains("\"Materials\":[\"Plaster\",\"Brick\"]", json);
            Assert.Contains("\"Id\":2", json);
            Assert.Contains("\"Name\":\"Element2\"", json);
            Assert.Contains("\"Category\":\"Floor\"", json);
            Assert.Contains("\"Materials\":[\"Concrete\"]", json);
        }
    }
}
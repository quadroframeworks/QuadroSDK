using Quadro.Documents;
using Quadro.Documents.UnitOfWork;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Quadro.Api
{
    public class UnitOfWorkConverter : JsonConverter<UnitOfWork>
    {

        private readonly IEntityTypeProvider typeProvider;
        public UnitOfWorkConverter(IEntityTypeProvider typeProvider)
        {
            this.typeProvider = typeProvider;
        }

        public override UnitOfWork? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Ensure the reader is at the start of an object
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException("Expected StartObject token");
            }

            var unitOfWork = new UnitOfWork();
            var containers = new List<DataContainer>();

            while (reader.Read()) // Read through JSON tokens
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    break; // End of UnitOfWork object

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string propertyName = reader.GetString()!;

                    reader.Read(); // Move to property value

                    if (propertyName == "Id")
                    {
                        unitOfWork.Id = reader.GetString()!;
                    }
                    else if (propertyName == "Containers")
                    {
                        if (reader.TokenType == JsonTokenType.StartArray)
                        {
                            while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                            {
                                containers.Add(ReadDataContainer(ref reader, options));
                            }
                        }
                    }
                }
            }

            unitOfWork.Containers = new ContainerCollection();
            unitOfWork.Containers.AddRange(containers);

            return unitOfWork;
        }

        private DataContainer ReadDataContainer(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException("Expected StartObject for DataContainer");

            var container = new DataContainer();
            string? modelJson = null;
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader)) // Capture the object as a JsonDocument
            {
                JsonElement root = doc.RootElement;

                if (root.TryGetProperty("Id", out JsonElement idElement))
                    container.Id = idElement.GetString()!;

                if (root.TryGetProperty("Hash", out JsonElement hashElement))
                    container.Hash = hashElement.GetString()!;

                if (root.TryGetProperty("Type", out JsonElement typeElement))
                    container.Type = typeElement.GetString()!;

                if (root.TryGetProperty("State", out JsonElement stateElement))
                    container.State = (DataContainerState)stateElement.GetInt32();

                if (root.TryGetProperty("Model", out JsonElement modelElement))
                    modelJson = modelElement.GetRawText(); // Extract raw JSON

                if (root.TryGetProperty("ViewModel", out JsonElement viewModelElement))
                    container.ViewModel = JsonSerializer.Deserialize<DataDocument>(viewModelElement.GetRawText(), options);
            }

            // Deserialize Model based on Type
            var typeName = container.Type;
            var targetType = typeProvider.GetType(typeName);
            if (!string.IsNullOrEmpty(typeName))
            {
                if (!string.IsNullOrEmpty(modelJson))
                {
                    container.Model = (IStorable?)JsonSerializer.Deserialize(modelJson, targetType, options)
                                      ?? throw new JsonException($"Failed to deserialize Model for type {typeName}");
                }
            }
            else if (!string.IsNullOrEmpty(typeName))
            {
                throw new JsonException($"Unknown type: {typeName}");
            }

            return container;
        }

        public override void Write(Utf8JsonWriter writer, UnitOfWork value, JsonSerializerOptions options)
        {
            // Implement your custom serialization logic if needed
            JsonSerializer.Serialize(writer, value);
        }
    }

}

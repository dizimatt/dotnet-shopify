using System.Text.Json.Serialization;

namespace shopify.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ProductStatus
    {
        Draft = 0,
        Active = 1
    }
}
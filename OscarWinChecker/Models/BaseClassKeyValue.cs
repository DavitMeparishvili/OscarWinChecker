using System.Text.Json.Serialization;

namespace OscarWinChecker.Models
{
    public class BaseClassKeyValue
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}

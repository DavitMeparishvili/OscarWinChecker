using System.Text.Json.Serialization;

namespace OscarWinChecker.Models
{
    public class MovieTitle
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("starList")]
        public List<BaseClassKeyValue> StarList { get; set; }
    }
}

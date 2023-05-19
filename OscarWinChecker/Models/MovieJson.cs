using System.Text.Json.Serialization;

namespace OscarWinChecker.Models
{
    public class MovieJson
    {
        [JsonPropertyName("searchType")]
        public string SearchType { get; set; }

        [JsonPropertyName("expression")]
        public string Expression { get; set; }

        [JsonPropertyName("results")]
        public List<Result> Results { get; set; }

        [JsonPropertyName("errorMessage")]
        public string ErrorMessage { get; set; }
    }
}

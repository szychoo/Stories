using System.Text.Json.Serialization;

namespace StoriesApi
{
    public class Story
    {
        [JsonPropertyName("by")]
        public string By { get; set; }

        [JsonPropertyName("descendants")]
        public int Descendants { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("kids")]
        public List<int> Kids { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonIgnore] 
        public DateTime Time { get; set; }

        [JsonPropertyName("time")]
        public long UnixTime
        {
            get => ((DateTimeOffset)Time).ToUnixTimeSeconds();
            set => Time = DateTimeOffset.FromUnixTimeSeconds(value).DateTime;
        }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
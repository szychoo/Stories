using System.Text.Json;

namespace StoriesApi
{
    public class HakerNewsClient : IHakerNewsClient
    {
        private readonly HttpClient _httpClient;
        public HakerNewsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<int>> GetBestStoriesAsync()
        {
            var response = await _httpClient.GetAsync("beststories.json");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<IEnumerable<int>>(content);
            return result ?? Enumerable.Empty<int>();
        }

        public async Task<Story> GetStoryByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"item/{id}.json");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var story = JsonSerializer.Deserialize<Story>(content);
            return story ?? new Story();
        }
    }
}

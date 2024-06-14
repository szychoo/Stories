namespace StoriesApi
{
    public interface IHakerNewsClient
    {
        public Task<IEnumerable<int>> GetBestStoriesAsync();

        public Task<Story> GetStoryByIdAsync(int id);
    }
}

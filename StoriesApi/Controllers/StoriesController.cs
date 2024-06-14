using Microsoft.AspNetCore.Mvc;
using StoriesApi;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class StoriesController : ControllerBase
{
    private readonly HakerNewsClient _hakerNewsClient;

    public StoriesController(HakerNewsClient hakerNewsClient)
    {
        _hakerNewsClient = hakerNewsClient;
    }

    [HttpGet]
    public async Task<IActionResult> GetBestStories(int n)
    {
        var bestStoriesIds = await _hakerNewsClient.GetBestStoriesAsync();
        var bestStories = new List<StoryDTO>();

        // Fetch details for the top 'n' stories
        foreach (var id in bestStoriesIds.Take(n))
        {
            var story = await _hakerNewsClient.GetStoryByIdAsync(id);
            if (story != null)
            {
                bestStories.Add(new StoryDTO
                {
                    PostedBy = story.By,
                    Title = story.Title,
                    Score = story.Score,
                    Time = story.Time,
                    Uri = story.Url,
                    CommentCount = story.Kids.Count
                });
            }
        }

        return Ok(bestStories);
    }
}

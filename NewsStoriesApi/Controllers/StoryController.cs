using Microsoft.AspNetCore.Mvc;
using NewsStoriesApi.Models;
using NewsStoriesApi.Services;

namespace NewsStoriesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IStoryService _storyService;
        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Story>>> Get(int numberOfStories)
        {
           var stories = await _storyService.GetBestStoriesAsync(numberOfStories);

            if (!stories.Any())
                NotFound();
            
            return Ok(stories);
        }
    }
}

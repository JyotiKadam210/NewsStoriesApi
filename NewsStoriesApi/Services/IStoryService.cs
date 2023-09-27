using NewsStoriesApi.Models;

namespace NewsStoriesApi.Services
{
    public interface IStoryService
    {
        public Task<IEnumerable<Story>> GetBestStoriesAsync(int n);
    }
}

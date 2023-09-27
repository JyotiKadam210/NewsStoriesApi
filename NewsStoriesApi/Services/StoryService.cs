using NewsStoriesApi.Client;
using NewsStoriesApi.Models;

namespace NewsStoriesApi.Services
{
    public class StoryService : IStoryService
    {

        private readonly INewsClient _newsClient;

        public StoryService(INewsClient newsClient)
        {
            _newsClient = newsClient;
        }

        public  Task<IEnumerable<Story>> GetBestStoriesAsync(int n)
        {
            return _newsClient.GetBestStoriesAsync(n);
        }
    }
}

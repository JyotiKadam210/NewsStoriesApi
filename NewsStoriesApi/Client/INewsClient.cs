using NewsStoriesApi.Models;

namespace NewsStoriesApi.Client
{
    public interface INewsClient
    {
        public Task<IEnumerable<Story>> GetBestStoriesAsync(int n);
    }
}

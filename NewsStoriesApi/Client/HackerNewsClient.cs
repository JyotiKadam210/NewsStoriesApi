using NewsStoriesApi.Mapper;
using NewsStoriesApi.Models;

namespace NewsStoriesApi.Client
{
    public class HackerNewsClient : INewsClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HackerNewsClient(IHttpClientFactory httpClientFactory) 
        { 
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Story>> GetBestStoriesAsync(int n)
        {
            var httpClient = _httpClientFactory.CreateClient("NewsApi");
            var storyIds = await GetBestStoryIdsAsync(httpClient);

            if (storyIds == null || !storyIds.Any())
            {
                return Enumerable.Empty<Story>();
            }

            var storyDetails = await GetStoryDetailsAsync(httpClient, storyIds);

            return storyDetails.OrderByDescending(story => story.Score).Take(n) ?? Enumerable.Empty<Story>();
        }

        private static async Task<IEnumerable<int>> GetBestStoryIdsAsync(HttpClient httpClient)
        {
            var task = await httpClient.GetFromJsonAsync<int[]>($"beststories.json?print=pretty");
            return  task ?? Array.Empty<int>();
        }

        private async Task<IEnumerable<Story>> GetStoryDetailsAsync(HttpClient httpClient, IEnumerable<int> storyIds)
        {
            var tasks = storyIds.Select(storyId => GetStoryDetailAsync(httpClient, storyId));
            var stories = await Task.WhenAll(tasks);
            return stories.Where(story => story != null) ?? Enumerable.Empty<Story>();
        }

        private static async Task<Story> GetStoryDetailAsync(HttpClient httpClient, int storyId)
        {
            var stortDetails = await httpClient.GetFromJsonAsync<StoryDetailsResponse>($"item/{storyId}.json?print=pretty");

            return stortDetails?.MapToStory();
        }

    }
}

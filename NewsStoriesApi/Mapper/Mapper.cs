using NewsStoriesApi.Models;

namespace NewsStoriesApi.Mapper
{
    public static class Mapper
    {
            public static Story MapToStory(this StoryDetailsResponse storyDetailsResponse)            {
               
                return new Story
                {
                    Title = storyDetailsResponse.Title,
                    Uri = storyDetailsResponse.Url,
                    PostedBy = storyDetailsResponse.By,
                    Time = DateTimeOffset.FromUnixTimeSeconds(storyDetailsResponse.Time),
                    Score = storyDetailsResponse.Score,
                    CommentCount = storyDetailsResponse.Descendants
                };
            }
        }
}

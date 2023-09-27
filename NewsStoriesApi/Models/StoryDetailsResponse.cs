namespace NewsStoriesApi.Models
{
    public class StoryDetailsResponse
    {
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? By { get; set; }
        public int Time { get; set; }
        public decimal Score { get; set; }
        public int Descendants { get; set; }
    }
}
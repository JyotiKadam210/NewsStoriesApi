﻿namespace NewsStoriesApi.Models
{
    public class Story
    {
        public string? Title { get; set; }
        public string? Uri { get; set; }
        public string? PostedBy { get; set; }
        public DateTimeOffset Time { get; set; }
        public decimal Score { get; set; }
        public int CommentCount { get; set; }
    }
}
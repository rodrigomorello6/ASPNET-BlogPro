namespace AspNetPro.Blog.Models.Entities.ViewModel
{
    public record PostDetailsViewModel
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? PublishedOn { get; set; }

        public IEnumerable<CommentItem> Comments { get; set; } 

        public record CommentItem
        {
            public string? Author { get; set; }
            public string? PublishedOn { get; set; }
            public string? Content { get; set; }
        }
    }
}

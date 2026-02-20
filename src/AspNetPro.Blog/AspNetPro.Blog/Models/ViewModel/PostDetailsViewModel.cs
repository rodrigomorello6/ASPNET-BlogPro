namespace AspNetPro.Blog.Models.ViewModel
{
    public record PostDetailsViewModel
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Tags { get; set; }
        public string? PublishedOn { get; set; }


        public CategoryViewModel Category { get; set; }

        public IEnumerable<CommentItem> Comments { get; set; }

        public IEnumerable<string> GetTags()
        { 
            if (String.IsNullOrWhiteSpace(this.Tags))
            {
                return Enumerable.Empty<string>();
            }

            return this.Tags.Split(",");
        }

        public record CommentItem
        {
            public string? Author { get; set; }
            public string? PublishedOn { get; set; }
            public string? Content { get; set; }
        }

        public record CategoryViewModel
        {
            public int CategoryId { get; set; }
            public string? Name { get; set; }
        }
    }
}

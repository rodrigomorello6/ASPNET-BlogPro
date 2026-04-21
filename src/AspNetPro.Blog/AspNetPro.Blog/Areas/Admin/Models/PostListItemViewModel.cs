namespace AspNetPro.Blog.Areas.Admin.Models
{
    public record PostListItemViewModel
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? PublishedOn { get; set; }
    }
}

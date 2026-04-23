namespace AspNetPro.Blog.Areas.Admin.Models.ViewModel
{
    public record PostListItemViewModel
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? PublishedOn { get; set; }
    }
}

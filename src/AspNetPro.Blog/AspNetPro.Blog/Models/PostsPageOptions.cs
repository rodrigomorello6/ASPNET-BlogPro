namespace AspNetPro.Blog.Models
{
    public record PostsPageOptions
    {
        public string? Q { get; init; }
        public int? Category { get; init; }
    }
}

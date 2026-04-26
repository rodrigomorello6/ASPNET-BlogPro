namespace AspNetPro.Blog.Models
{
    public record PostsPageOptions
    {
        public string? Q { get; init; }
        public string? Category { get; init; }
        public int? Page { get; init; }        
        public int? PageSize { get; init; } = 10; 
    }
}

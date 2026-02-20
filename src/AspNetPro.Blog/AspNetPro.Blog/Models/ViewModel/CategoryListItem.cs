namespace AspNetPro.Blog.Models.ViewModel
{
    public record CategoryListItem
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int TotalPosts { get; set; }
    }
}

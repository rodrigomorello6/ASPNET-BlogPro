namespace AspNetPro.Blog.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>(0);
    }
}

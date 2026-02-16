using System.Data;

namespace AspNetPro.Blog.Models.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Author { get; set; }
        public string? Content { get; set; }
        public DateTime? PublishedOn { get; set; } = DateTime.Now;
        public Post Post { get; set; }


    }
}

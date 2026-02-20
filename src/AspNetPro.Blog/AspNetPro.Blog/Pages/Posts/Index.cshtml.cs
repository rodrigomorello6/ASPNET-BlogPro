using AspNetPro.Blog.Infrastruture.Data;
using AspNetPro.Blog.Models.Entities;
using AspNetPro.Blog.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetPro.Blog.Pages.Posts;

public class IndexModel(BlogContext blogContext) : PageModel
{
    public IList<PostItemListViewModel> Posts { get; set; }
    public void OnGet(string q)
    {
        IQueryable<Post> posts = blogContext.Posts;

        if (!String.IsNullOrWhiteSpace(q))
        {
            posts = posts.Where(post =>
                post.Title.Contains(q) ||
                post.Summary.Contains(q) ||
                post.Content.Contains(q)
            );
        }

        Posts = posts
            .OrderByDescending(x => x.PublishedOn)
            .Select(x => new PostItemListViewModel
            {
                PostId = x.Id,
                Title = x.Title,
                Summary = x.Summary,
                PublishedOn = x.PublishedOn.Value.ToShortDateString()
            })
            .ToList();
    }
}

using AspNetPro.Blog.Infrastruture.Data;
using AspNetPro.Blog.Models;
using AspNetPro.Blog.Models.Entities;
using AspNetPro.Blog.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetPro.Blog.Pages.Posts;

public class IndexModel(BlogContext blogContext) : PageModel
{
    public IList<PostItemListViewModel> Posts { get; set; }
    public void OnGet([FromQuery] PostsPageOptions pageOptions)
    {
        IQueryable<Post> posts = blogContext.Posts
            .Include(x => x.Category);

        if (!String.IsNullOrWhiteSpace(pageOptions.Q))
        {
            posts = posts.Where(post =>
                post.Title.Contains(pageOptions.Q) ||
                post.Summary.Contains(pageOptions.Q) ||
                post.Content.Contains(pageOptions.Q)
            );
        }

        if (pageOptions.Category.HasValue)
        { 
            posts = posts.Where(post => post.Category.Id == pageOptions.Category.Value);
        }

        Posts = posts
            .OrderByDescending(x => x.PublishedOn)
            .Select(x => new PostItemListViewModel
            {
                PostId = x.Id,
                Title = x.Title,
                Summary = x.Summary,
                PublishedOn = x.PublishedOn.Value.ToShortDateString(),
                Category = new PostItemListViewModel.CategoryViewModel
                {
                    CategoryId = x.Category.Id,
                    Name = x.Category.Name
                }
            })
            .ToList();
    }
}

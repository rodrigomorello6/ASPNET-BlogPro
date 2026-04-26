using AspNetPro.Blog.Infrastruture.Data;
using AspNetPro.Blog.Models;
using AspNetPro.Blog.Models.Entities;
using AspNetPro.Blog.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

        if (!string.IsNullOrEmpty(pageOptions.Category))
        {
            posts = posts.Where(post => post.Category.Permalink == pageOptions.Category);
        }

        int pageNumber = pageOptions.Page ?? 1;
        int pageSize = pageOptions.PageSize ?? 10;

        Posts = posts
            .OrderByDescending(x => x.PublishedOn)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(x => new PostItemListViewModel
            {
                PostId = x.Id,
                Title = x.Title,
                Summary = x.Summary,
                Permalink = x.Permalink,
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

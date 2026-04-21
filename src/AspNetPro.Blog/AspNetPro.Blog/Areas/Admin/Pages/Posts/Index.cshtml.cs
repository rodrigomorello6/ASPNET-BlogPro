using AspNetPro.Blog.Areas.Admin.Models;
using AspNetPro.Blog.Infrastruture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetPro.Blog.Areas.Admin.Pages.Posts;

public class IndexModel(BlogContext blogContext) 
    : PageModel
{
    public IList<PostListItemViewModel> Posts { get; set; }

    public void OnGet()
    {
        this.Posts = blogContext.Posts
            .OrderByDescending(x => x.PublishedOn)
            .Select(x => new PostListItemViewModel
            {
                PostId = x.Id,
                Title = x.Title,
                PublishedOn = x.PublishedOn.Value.ToShortDateString()
            })
            .ToList();
    }
}

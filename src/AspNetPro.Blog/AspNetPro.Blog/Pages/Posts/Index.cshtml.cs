using AspNetPro.Blog.Infrastruture.Data;
using AspNetPro.Blog.Models.Entities;
using AspNetPro.Blog.Models.Entities.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetPro.Blog.Pages.Posts;

public class IndexModel(BlogContext blogContext) : PageModel
{
    public IList<PostItemListViewModel> Posts { get; set; }
    public void OnGet()
    {
        this.Posts = blogContext.Posts
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

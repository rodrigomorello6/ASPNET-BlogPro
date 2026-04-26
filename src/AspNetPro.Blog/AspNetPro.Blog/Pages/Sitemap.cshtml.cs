using AspNetPro.Blog.Infrastruture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetPro.Blog.Pages;

public class Sitemap(BlogContext blogContext) : PageModel
{
    public IList<string?> PostsPermalink { get; set; }
    public IList<string?> CategoriesPermalink { get; set; }


    public void OnGet()
    {
        this.PostsPermalink = blogContext.Posts
            .OrderByDescending(x => x.Id)
            .Select(x => x.Permalink)
            .ToList();

        this.CategoriesPermalink = blogContext.Categories
            .OrderBy(x => x.Name)
            .Select(x => x.Permalink)
            .ToList();

    }
}

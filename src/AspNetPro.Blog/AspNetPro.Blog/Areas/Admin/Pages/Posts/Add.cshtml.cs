  using AspNetPro.Blog.Areas.Admin.Models.FormModel;
using AspNetPro.Blog.Common;
using AspNetPro.Blog.Infrastruture.Data;
using AspNetPro.Blog.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetPro.Blog.Areas.Admin.Pages.Posts;

public class AddModel(BlogContext blogContext)
    : BaseModel
{
    [BindProperty]
    public PostFormModel PostForm { get; set; }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Post newPost = new Post
        {
            Permalink = PostForm.Permalink,
            Title = PostForm.Title,
            Summary = PostForm.Summary,
            Content = PostForm.Content,
            Tag = PostForm.Tags
        };

        if (!String.IsNullOrWhiteSpace(PostForm.Category))
        {
            string permlink = PostForm.Category.ToSlug();

            newPost.Category = await blogContext.Categories
                .FirstOrDefaultAsync(x => x.Permalink == permlink);
            if (newPost.Category == null)
            {
                newPost.Category = new Category
                {
                    Name = PostForm.Category,
                    Permalink = permlink
                };
            }
        }
        else
        {
            newPost.Category = null;
        }

        try
        {
            blogContext.Add(newPost);
            await blogContext.SaveChangesAsync();

            Success("Your post has been saved");
        }
        catch (Exception)
        {
            // log

            Error("Your post cannot saved");
            return Page();
        }

       

        return RedirectToPage("/Posts/Edit", new { postId = newPost.Id });
    }
}

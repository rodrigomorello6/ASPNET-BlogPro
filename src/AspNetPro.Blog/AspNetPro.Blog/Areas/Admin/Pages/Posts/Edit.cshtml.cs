using AspNetPro.Blog.Areas.Admin.Models.FormModel;
using AspNetPro.Blog.Common;
using AspNetPro.Blog.Infrastruture.Data;
using AspNetPro.Blog.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetPro.Blog.Areas.Admin.Pages.Posts;

public class EditModel(BlogContext blogContext)
    : BaseModel
{
    [BindProperty]
    public PostFormModel PostForm { get; set; }

    public async Task<IActionResult> OnGetAsync([FromRoute] int postId)
    {
        Post post = await GetPostById(postId);
        if (post == null)
        {
            return NotFound();
        }

        this.PostForm = new PostFormModel
        {
            PostId = post.Id,
            Title = post.Title,
            Summary = post.Summary,
            Content = post.Content,
            Category = post.Category.Name,
            Tags = post.Tag
        };

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(
        [FromRoute] int postId)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Post post = await GetPostById(postId);
        if (post == null)
        {
            return NotFound();
        }

        post.Permalink = PostForm.Permalink;
        post.Title = PostForm.Title;
        post.Summary = PostForm.Summary;
        post.Content = PostForm.Content;
        post.Tag = PostForm.Tags;

        if (!String.IsNullOrWhiteSpace(PostForm.Category))
        {
            string permlink = PostForm.Category.ToSlug();

            post.Category = await blogContext.Categories
                .FirstOrDefaultAsync(x => x.Permalink == permlink);

            if (post.Category == null)
            {
                post.Category = new Category
                {
                    Name = PostForm.Category,
                    Permalink = permlink
                };
            }
        }
        else
        {
            post.Category = null;
        }


        try
        {
            blogContext.Update(post);
            await blogContext.SaveChangesAsync();

            Success("Your post has been saved");
        }
        catch (Exception)
        {
            Error("Your post cannot saved");
        }

        return Page();
    }


    private Task<Post> GetPostById(int postId)
    {
        return blogContext.Posts
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == postId);
    }
}

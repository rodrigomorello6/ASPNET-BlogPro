using AspNetPro.Blog.Areas.Admin.Models.ViewModel;
using AspNetPro.Blog.Infrastruture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetPro.Blog.Areas.Admin.Pages.Posts
{
    public class DeleteModel (BlogContext blogContext)
        : PageModel
    {
        public PostDeleteViewModel Post { get; set; }
        public async Task<IActionResult> OnGetAsync([FromRoute] int postId)
        {
            var post = await blogContext.Posts
                .FirstOrDefaultAsync(x => x.Id == postId);
            if (post == null) 
            { 
                return NotFound();
            }

            this.Post = new PostDeleteViewModel
            {
                Title = post.Title,
                Summary = post.Summary
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromRoute] int postId)
        { 
            await blogContext.Posts
                .Where(x => x.Id == postId)
                .ExecuteDeleteAsync();

            await blogContext.SaveChangesAsync();

            return RedirectToPage("/Posts/Index");
        }
    }
}

using AspNetPro.Blog.Infrastruture.Data;
using AspNetPro.Blog.Models.Entities.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetPro.Blog.Pages.Posts
{
    public class DetailsModel(BlogContext blogContext) : PageModel
    {
        public PostDetailsViewModel? Post { get; set; }

        public async Task<IActionResult> OnGet([FromRoute]int postId)
        {
            this.Post = await blogContext.Posts
                 .Where(x => x.Id == postId)
                 .Select(x => new PostDetailsViewModel
                 {
                     PostId = x.Id,
                     Title = x.Title,
                     Content = x.Content,
                     PublishedOn = x.PublishedOn.Value.ToShortDateString()
                 })
                 .FirstOrDefaultAsync();

            if (this.Post == null) 
            {
                return NotFound();
            }

            return Page();
        }
    }
}

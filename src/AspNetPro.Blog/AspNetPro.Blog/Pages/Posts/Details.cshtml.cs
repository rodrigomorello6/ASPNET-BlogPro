using AspNetPro.Blog.Infrastruture.Data;
using AspNetPro.Blog.Models.Entities;
using AspNetPro.Blog.Models.Entities.FormModel;
using AspNetPro.Blog.Models.Entities.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetPro.Blog.Pages.Posts
{
    public class DetailsModel(BlogContext blogContext) : PageModel
    {

        public PostDetailsViewModel? Post { get; set; }

        public async Task<IActionResult> OnGet([FromRoute] int postId)
        {
            this.Post = await blogContext.Posts
                 .Where(x => x.Id == postId)
                 .Select(x => new PostDetailsViewModel
                 {
                     PostId = x.Id,
                     Title = x.Title,
                     Content = x.Content,
                     PublishedOn = x.PublishedOn.Value.ToShortDateString(),
                     Comments = x.Comments.Select(y => new PostDetailsViewModel.CommentItem
                     {
                         Author = y.Author,
                         Content = y.Content,
                         PublishedOn = y.PublishedOn.Value.ToString("dd/MM/yyyy hh:mm")
                     })
                 })
                 .FirstOrDefaultAsync();

            if (this.Post == null)
            {
                return NotFound();
            }

            return Page();
        }

        [BindProperty]
        public CommentFormModel CommentForm { get; set; }

        public async Task<IActionResult> OnPost()
        {
            var comment = new Comment
            {
                Author = CommentForm.Author,
                Content = CommentForm.Content,
                Post = await blogContext.Posts.FindAsync(CommentForm.PostId)
            };

            blogContext.Comments.Add(comment);
            await blogContext.SaveChangesAsync();

            return RedirectToPage("/Posts/Details", new { postId = CommentForm.PostId });
        }
    }
}

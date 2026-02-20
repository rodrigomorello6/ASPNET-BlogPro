using AspNetPro.Blog.Infrastruture.Data;
using AspNetPro.Blog.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AspNetPro.Blog.Components
{
    [ViewComponent(Name ="CategoryListViewComponent")]
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly BlogContext blogContext;

        public CategoryListViewComponent(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await (from c in blogContext.Categories
                               select new CategoryListItem
                               {
                                   Id = c.Id,
                                   Name = c.Name,
                                   TotalPosts = c.Posts.Count()
                               })
                               .ToListAsync();
            return View("Default", model);
        }
    }
}

using AspNetPro.Blog.Infrastruture.Data;

namespace AspNetPro.Blog.Infrastruture.Web;

public class PostRouteConstraint : IRouteConstraint
{
    private readonly IServiceProvider serviceProvider;

    public PostRouteConstraint(IServiceProvider serviceProvider)
    { 
        this.serviceProvider = serviceProvider;
    }
    public bool Match(HttpContext? httpContext, 
        IRouter? route, 
        string routeKey, 
        RouteValueDictionary values, 
        RouteDirection routeDirection)
    {
        if (routeDirection == RouteDirection.UrlGeneration)
        {
            return true;
        }
        if (routeKey != "permalink")
        {
            return true;
        }

        var permalink = values[routeKey].ToString().ToLowerInvariant();

        using (var scope = this.serviceProvider.CreateScope())
        {
            var blogContext = scope.ServiceProvider.GetRequiredService<BlogContext>();

            return blogContext.Posts.Any(x => x.Permalink == permalink);
        }

            
    }
}

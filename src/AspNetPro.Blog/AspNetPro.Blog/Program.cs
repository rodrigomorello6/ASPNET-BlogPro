using AspNetPro.Blog.Infrastruture.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddRazorPages();

builder.Services.AddDbContext<BlogContext>((optionsAction) =>
{
    var connString = config.GetConnectionString("BlogConnection");
    optionsAction.UseMySQL(connString);
});

builder.Services
    .AddFluentEmail(
        defaultFromEmail: config["MailSettings:DefaultFromEmail"],
        defaultFromName: config["MailSettings:DefaultFromName"])
    .AddSmtpSender(
        host: config["MailSettings:Host"],
        port: 587,
        username: config["MailSettings:Username"],
        password: config["MailSettings:Password"]);

var app = builder.Build();

app.UseStaticFiles();

app.MapRazorPages();

app.Run();

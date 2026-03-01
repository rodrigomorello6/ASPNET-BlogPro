using AspNetPro.Blog.Models.FormModel;
using FluentEmail.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetPro.Blog.Pages;

public class ContactModel(IFluentEmail email) : PageModel
{
    [BindProperty]
    public ContactFormModel ContactForm { get; set; }

    public void OnPost()
    {
        var response = email
            .To("rodrigomorello6@gmail.com", "Rodrigo Morello")
            .ReplyTo(ContactForm?.Email, ContactForm?.Name)
            .Subject("New contact")
            .Body(ContactForm?.Message)
            .Send();

        if (!response.Successful)
        {
            ViewData["MSG_ERROR"] = response.ErrorMessages.FirstOrDefault();
        }


    }
}

namespace RazorWeb.Pages
{
    using System;
    using System.Threading.Tasks;
    using Piranha;
    using RazorWeb.Models;

    public class PostModel : Microsoft.AspNetCore.Mvc.RazorPages.PageModel
    {
        private readonly IApi api;

        public PostModel(IApi api)
        {
            this.api = api;
        }

        public BlogPost Data { get; private set; }

        public async Task OnGet(Guid id)
        {
            this.Data = await this.api.Posts.GetByIdAsync<BlogPost>(id);
        }
    }
}
namespace RazorWeb.Pages
{
    using System;
    using System.Threading.Tasks;
    using Piranha;
    using RazorWeb.Models;

    public class PageModel : Microsoft.AspNetCore.Mvc.RazorPages.PageModel
    {
        private readonly IApi api;

        public PageModel(IApi api)
        {
            this.api = api;
        }

        public StandardPage Data { get; private set; }

        public async Task OnGet(Guid id)
        {
            this.Data = await this.api.Pages.GetByIdAsync<StandardPage>(id);
        }
    }
}
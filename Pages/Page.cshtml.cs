namespace RazorWeb.Pages
{
    using System;
    using System.Threading.Tasks;
    using Piranha;
    using RazorWeb.Models;

    public class PageModel : Microsoft.AspNetCore.Mvc.RazorPages.PageModel
    {
        private readonly IApi _api;

        public PageModel(IApi api)
        {
            this._api = api;
        }

        public StandardPage Data { get; private set; }

        public async Task OnGet(Guid id)
        {
            this.Data = await this._api.Pages.GetByIdAsync<StandardPage>(id);
        }
    }
}
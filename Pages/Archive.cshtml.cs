namespace RazorWeb.Pages
{
    using System;
    using System.Threading.Tasks;
    using Piranha;
    using RazorWeb.Models;

    public class ArchiveModel : Microsoft.AspNetCore.Mvc.RazorPages.PageModel
    {
        private readonly IApi _api;

        public ArchiveModel(IApi api)
        {
            this._api = api;
        }

        public BlogArchive Data { get; private set; }

        public async Task OnGet(Guid id, int? year = null, int? month = null, int? page = null,
            Guid? category = null, Guid? tag = null)
        {
            this.Data = await this._api.Pages.GetByIdAsync<BlogArchive>(id);
            this.Data.Archive = await this._api.Archives.GetByIdAsync(id, page, category, tag, year, month);
        }
    }
}
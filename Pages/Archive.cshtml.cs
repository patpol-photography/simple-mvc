namespace RazorWeb.Pages
{
    using System;
    using System.Threading.Tasks;
    using Piranha;
    using RazorWeb.Models;

    public class ArchiveModel : Microsoft.AspNetCore.Mvc.RazorPages.PageModel
    {
        private readonly IApi api;

        public ArchiveModel(IApi api)
        {
            this.api = api;
        }

        public BlogArchive Data { get; private set; }

        public async Task OnGet(Guid id, int? year = null, int? month = null, int? page = null,
            Guid? category = null, Guid? tag = null)
        {
            this.Data = await this.api.Pages.GetByIdAsync<BlogArchive>(id);
            this.Data.Archive = await this.api.Archives.GetByIdAsync(id, page, category, tag, year, month);
        }
    }
}
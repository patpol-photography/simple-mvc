namespace RazorWeb.Pages
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Piranha;
    using Piranha.Models;
    using RazorWeb.Models;

    public class TeaserPageModel : Microsoft.AspNetCore.Mvc.RazorPages.PageModel
    {
        private readonly IApi api;
        private readonly IDb db;

        public TeaserPageModel(IApi api, IDb db)
        {
            this.api = api;
            this.db = db;
        }

        public TeaserPage Data { get; private set; }

        public async Task OnGet(Guid id, bool startpage = false)
        {
            this.Data = await this.api.Pages.GetByIdAsync<TeaserPage>(id);

            if (startpage)
            {
                var latest = await this.db.Posts
                    .Where(p => p.Published <= DateTime.Now)
                    .OrderByDescending(p => p.Published)
                    .Take(1)
                    .Select(p => p.Id)
                    .ToListAsync();

                if (latest.Count() > 0)
                {
                    this.Data.LatestPost = await this.api.Posts
                        .GetByIdAsync<PostInfo>(latest.First());
                }
            }
        }
    }
}
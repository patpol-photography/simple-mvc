/*
 * Copyright (c) 2017-2018 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 * 
 * http://github.com/tidyui/coreweb
 * 
 */

namespace RazorWeb.Models
{
    using System.Collections.Generic;
    using Piranha.AttributeBuilder;
    using Piranha.Models;
    using RazorWeb.Models.Regions;

    /// <summary>
    ///     Basic page with main content in markdown.
    /// </summary>
    [PageType(Title = "Teaser Page")]
    [PageTypeRoute(Title = "Default", Route = "/teaserpage")]
    public class TeaserPage : Page<TeaserPage>
    {
        /// <summary>
        ///     Gets/sets the page header.
        /// </summary>
        [Region]
        public Hero Hero { get; set; }

        /// <summary>
        ///     Gets/sets the available teasers.
        /// </summary>
        [Region(ListTitle = "Title", ListPlaceholder = "New Teaser")]
        public IList<Teaser> Teasers { get; set; } = new List<Teaser>();

        /// <summary>
        ///     Gets/sets the available teasers.
        /// </summary>
        [Region(ListTitle = "Title", ListPlaceholder = "New Quote")]
        public IList<Teaser> Quotes { get; set; } = new List<Teaser>();

        /// <summary>
        ///     Gets/sets the latest post.
        /// </summary>
        public PostInfo LatestPost { get; set; }
    }
}
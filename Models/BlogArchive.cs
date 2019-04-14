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
    using Piranha.AttributeBuilder;
    using Piranha.Models;
    using RazorWeb.Models.Regions;

    /// <summary>
    ///     Basic blog page.
    /// </summary>
    [PageType(Title = "Blog archive", UseBlocks = false)]
    public class BlogArchive : ArchivePage<BlogArchive>
    {
        /// <summary>
        ///     Gets/sets the page header.
        /// </summary>
        [Region]
        public Hero Hero { get; set; }
    }
}
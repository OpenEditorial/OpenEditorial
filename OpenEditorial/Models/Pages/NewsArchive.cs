using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;

namespace OpenEditorial.Models.Pages
{
    [PageType(Title = "Архив новостей", UseBlocks = false, IsArchive = true)]
    [PageTypeArchiveItem(typeof(NewsPost))]
    [ContentTypeRoute(Title = "news", Route = "/news")]
    public class NewsArchive : Page<NewsArchive>
    {
        /// <summary>
        /// View model property for storing the current archive items.
        /// </summary>
        public PostArchive<NewsPost> Archive { get; set; }
    }
}

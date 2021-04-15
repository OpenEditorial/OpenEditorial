using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;


namespace OpenEditorial.Models.Pages
{
    [PageType(Title = "Библиотека книг", UseBlocks = false, IsArchive = true)] //Editorial Board Page
    [PageTypeArchiveItem(typeof(BooksPost))]
    [ContentTypeRoute(Title = "booksarchive", Route = "/booksarchive")]
    public class BooksArchive : Page<BooksArchive>
    {
        /// <summary>
        /// View model property for storing the current archive items.
        /// </summary>
        public PostArchive<BooksPost> Archive { get; set; }
    }
}

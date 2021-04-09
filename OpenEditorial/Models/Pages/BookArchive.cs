using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;


namespace OpenEditorial.Models.Pages
{
    [PageType(Title = "Библиотека книг", UseBlocks = false, IsArchive = true)]
    [PageTypeArchiveItem(typeof(BookPost))]
    public class BookArchive : Page<BookArchive>
    {
        /// <summary>
        /// View model property for storing the current archive items.
        /// </summary>
        public PostArchive<BookPost> Archive { get; set; }
    }
}

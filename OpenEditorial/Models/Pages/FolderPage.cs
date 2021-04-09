using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;
using Piranha.Extend.Fields;

namespace OpenEditorial.Models.Pages
{
    [PageType(Title = "Каталог", UseBlocks = false)]
    [ContentTypeRoute(Title = "Narrow", Route = "/folder")]
    //[ContentTypeRoute(Title = "Wide", Route = "/pagewide")]
    public class FolderPage : Page<FolderPage>
    {
        [Region(Title = "Страница по умолчанию")]
        public PageField DefaultPage { get; set; }
    }
}

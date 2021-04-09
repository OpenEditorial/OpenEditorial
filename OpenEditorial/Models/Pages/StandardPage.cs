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
    [PageType(Title = "Стандартная страница", UseBlocks = false)] //Standard Page
    [ContentTypeRoute(Title = "Narrow", Route = "/page")]
    //[ContentTypeRoute(Title = "Wide", Route = "/pagewide")]
    public class StandardPage : Page<StandardPage>
    {
        [Region(Title = "Текст")]
        public HtmlField Body { get; set; }
    }
}

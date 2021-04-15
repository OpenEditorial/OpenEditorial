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
    [PageType(Title = "Подписаться", UseBlocks = false)] //Standard Page
    [ContentTypeRoute(Title = "subscribe", Route = "/subscribe")]
    public class SubscribePage : Page<StandardPage>
    {
        [Region(Title = "Разметка")]
        public HtmlField Body { get; set; }
    }
}

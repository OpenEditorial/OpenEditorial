using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace OpenEditorial.Models.Pages
{
    [PostType(Title = "Новость")]
    public class NewsPost : Post<NewsPost>
    {
        [Region(Title = "Аннотация")]
        public HtmlField Abstract { get; set; }

        /*[Region(Title = "Текст")]
        public HtmlField Text { get; set; }*/
    }
}

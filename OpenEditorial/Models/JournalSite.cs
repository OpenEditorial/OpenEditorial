using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;
using Piranha.Extend.Fields;

namespace OpenEditorial.Models
{
    [SiteType(Title = "Сайт журнала")]
    public class JournalSite : SiteContent<JournalSite>
    {
        public class JournalInfo
        {
            [Field(Title = "Название")]
            public StringField Title { get; set; }

            [Field(Title = "ISSN")]
            public StringField ISSN { get; set; }
        }

        [Region(Title = "Журнал")]
        public JournalInfo Info { get; set; }

        [Region(Title = "Баннеры")]
        public HtmlField Banners { get; set; }

        [Region(Title = "Подвал")]
        public HtmlField Footer { get; set; }
    }
}

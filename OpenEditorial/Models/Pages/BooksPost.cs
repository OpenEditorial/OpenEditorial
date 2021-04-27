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
    [PostType(Title = "Книга", UseBlocks = false)]
    [ContentTypeRoute(Title = "bookspost", Route = "/bookspost")]
    public class BooksPost : Post<BooksPost>
    {
        public class BookRegion
        {
            [Field(Title = "Название")]
            public StringField Title { get; set; }

            [Field(Title = "Обложка")]
            public ImageField Image { get; set; }

            [Field(Title = "Аннотация")]
            public TextField Abstract { get; set; }

            [Field(Title = "Выходные данные")]
            public TextField Citing { get; set; }

            [Field(Title = "Рецензенты")]
            public TextField Reviewers { get; set; }

            [Field(Title = "Внешняя ссылка")]
            public StringField BuyUrl { get; set; }

            [Field(Title = "Связь с автором (email)")]
            public StringField Email { get; set; }

            [Field(Title = "Полнотекстовый файл")]
            public DocumentField FullTextFile { get; set; }
        }

        [Region]
        public BookRegion Book { get; set; }
    }
}

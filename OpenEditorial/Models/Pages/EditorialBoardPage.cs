using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;
using Piranha.Extend.Fields;

namespace OpenEditorial.Models.Pages
{
    [PageType(Title = "Редколлегия", UseBlocks = false)] //Editorial Board Page
    [ContentTypeRoute(Title = "editorialboard", Route = "/editorialboard")]
    public class EditorialBoardPage : Page<EditorialBoardPage>
    {
        public class EditorialBoardMember
        {
            public enum MemberTitle
            {
                [Display(Name="Главный редактор", GroupName = "Главный редактор", Description = "Главный редактор")]
                Editor,
                [Display(Name = "Ответственный секретарь", GroupName = "Ответственный секретарь", Description = "Ответственный секретарь")]
                ExecutiveSecretary,
                [Display(Name = "Член редколлегии", GroupName = "Члены редколлегии", Description = "Член редколлегии")]
                Member
            }

            [Field(Title = "Полное имя", Placeholder = "Укажите полное имя")]
            public StringField FullName { get; set; }

            [Field(Title = "Должность", Placeholder = "Укажите должность")]
            public SelectField<MemberTitle> Title { get; set; }

            [Field(Title = "Фото", Placeholder = "Можете добавить фото")]
            public ImageField Image { get; set; }

            [Field(Title = "Дополнительная информация", Placeholder = "Дополнительная информация")]
            public StringField About { get; set; }
        }

        [Region(ListTitle = "Члены редколлегии", ListExpand = false, ListPlaceholder = "Члены редколлегии", Icon = "fas fas-user-alt")]
        public IList<EditorialBoardMember> Members { get; set; }
    }
}

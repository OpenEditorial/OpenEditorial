using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Piranha;
using Piranha.AspNetCore.Services;

namespace OpenEditorial.Services
{
    public class UI : IUI
    {
        private readonly IApi _api;
        private readonly IApplicationService _app;

        public UI(IApi api, IApplicationService app)
        {
            _api = api;
            _app = app;
        }
        public string Permalink(string pageTypeId)
        {
            var pages = _api.Pages.GetAllAsync<Models.Pages.IssuePage>(_app.Site.Id).Result;
            var page = pages.FirstOrDefault(p => p.TypeId == pageTypeId);
            if (page == null)
                return "";
            
            return page.Permalink;
        }
    }
}

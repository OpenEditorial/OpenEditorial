using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Piranha;
using Piranha.AspNetCore.Services;
using Piranha.Models;

namespace OpenEditorial.Controllers
{
    public class CmsController : Controller
    {
        private readonly IApi _api;
        private readonly IDb _db;
        private readonly IModelLoader _loader;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="app">The current app</param>
        public CmsController(IApi api, IDb db, IModelLoader loader)
        {
            _api = api;
            _db = db;
            _loader = loader;
        }

        /// <summary>
        /// Gets the page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [HttpGet]
        [Route("page")]
        public async Task<IActionResult> Page(Guid id, bool draft = false)
        {
            var model = await _loader.GetPageAsync<Models.Pages.StandardPage>(id, HttpContext.User, draft);

            return View(model);
        }

        /// <summary>
        /// Gets the page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [HttpGet]
        [Route("news")]
        public async Task<IActionResult> NewsArchive(Guid id, bool draft = false)
        {
            var model = await _loader.GetPageAsync<Models.Pages.NewsArchive>(id, HttpContext.User, draft);
            model.Archive = await _api.Archives.GetByIdAsync<Models.Pages.NewsPost>(model.Id);

            return View(model);
        }

        /// <summary>
        /// Gets the page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [HttpGet]
        [Route("folder")]
        public async Task<IActionResult> Folder(Guid id, bool draft = false)
        {
            var model = await _loader.GetPageAsync<Models.Pages.FolderPage>(id, HttpContext.User, draft);
            return Redirect(model.DefaultPage.Page.Permalink);

            //return View(model);
        }
    }
}

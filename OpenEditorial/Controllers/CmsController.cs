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
        [Route("newspost")]
        public async Task<IActionResult> NewsPost(Guid id, bool draft = false)
        {
            var model = await _loader.GetPostAsync<Models.Pages.NewsPost>(id, HttpContext.User, draft);

            return View(model);
        }

        /// <summary>
        /// Gets the page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [HttpGet]
        [Route("newsarchive")]
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
            if (model.DefaultPage.HasValue)
                return Redirect(model.DefaultPage.Page.Permalink);
            else
            {
                var startPage = await _api.Pages.GetStartpageAsync();
                return Redirect(startPage.Permalink);
            }
        }

        /// <summary>
        /// Gets the page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [HttpGet]
        [Route("booksarchive")]
        public async Task<IActionResult> BooksArchive(Guid id, bool draft = false)
        {
            var model = await _loader.GetPageAsync<Models.Pages.BooksArchive>(id, HttpContext.User, draft);
            model.Archive = await _api.Archives.GetByIdAsync<Models.Pages.BooksPost>(model.Id);

            return View(model);
        }

        /// <summary>
        /// Gets the page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [HttpGet]
        [Route("bookspost")]
        public async Task<IActionResult> BooksPost(Guid id, bool draft = false)
        {
            var model = await _loader.GetPostAsync<Models.Pages.BooksPost>(id, HttpContext.User, draft);

            return View(model);
        }

        /// <summary>
        /// Gets the page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [HttpGet]
        [Route("editorialboard")]
        public async Task<IActionResult> EditorialBoard(Guid id, bool draft = false)
        {
            var model = await _loader.GetPageAsync<Models.Pages.EditorialBoardPage>(id, HttpContext.User, draft);

            return View(model);
        }
    }
}

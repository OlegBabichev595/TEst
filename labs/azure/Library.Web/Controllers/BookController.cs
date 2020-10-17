using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Library.Core.Entities;
using Library.Core.Repositories;
using Library.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _uow;

        public BookController(IUnitOfWork uow) => _uow = uow;

        [Route("[controller]/[action]")]


        
        public IActionResult List(BookListViewModel model)
        {
            // if first time - read from cookie
            model.PublisherId ??= Request.Cookies["filter"];

            model.Publishers = _uow.PublisherRepository.List();

            Expression<Func<Book, bool>> filter = null;
            if (Guid.TryParse(model.PublisherId, out var publisherId))
            {
                filter = x => x.PublisherId == publisherId;
            }
            else if (model.PublisherId == "None")
            {
                filter = x => x.PublisherId == null;
            }

            // set cookie
            if (model.PublisherId != null)
            {
                Response.Cookies.Append("filter", model.PublisherId);
            }

            model.Books = _uow.BookRepository.List(filter);
            return View(model);
        }

        [Route("[controller]/[action]/{id:guid}")]
        public IActionResult Details(Guid id)
        {
            var book = _uow.BookRepository.Find(id);
            return book == null ? (IActionResult) NotFound() : View(book);
        }

        [Route("[controller]/[action]/{id:guid}")]
        public IActionResult Favorites(Guid id)
        {
            var str = HttpContext.Session.GetString("favorites");
            if (!string.IsNullOrEmpty(str))
            {
                var ids = new HashSet<Guid>(str.Split("*").Select(Guid.Parse)) {id};
                HttpContext.Session.SetString("favorites", string.Join('*', ids.Select(x => x.ToString())));
            }
            else
            {
                HttpContext.Session.SetString("favorites", id.ToString());
            }

            return RedirectToAction("List", "Favorites");
        }
    }
}
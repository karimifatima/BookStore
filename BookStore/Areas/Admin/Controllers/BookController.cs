using AutoMapper;
using BookStore.IRepository;
using BookStore.Models;
using BookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    [RouteArea("Admin", AreaPrefix = "Admin")]
    [RoutePrefix("Book")]
    public class BookController : Controller
    {
        private readonly IGenericRepository<Book> _books;
        private readonly IMapper _mapper;

        public BookController(IGenericRepository<Book> books, IMapper mapper)
        {
            _books = books;
            _mapper = mapper;
        }

        [Route("List")]
        public async Task<ActionResult> List()
        {
            var books = await _books.GetAllAsync();
            var results = _mapper.Map<IList<BookViewModel>>(books);

            return View(results);
        }
    }
}
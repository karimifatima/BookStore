using AutoMapper;
using BookStore.IRepository;
using BookStore.Models;
using BookStore.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        private readonly IGenericRepository<StaffPic> _staffPics;
        private readonly IGenericRepository<Book> _books;
        private readonly IMapper _mapper;

        public HomeController(IGenericRepository<StaffPic> staffPics, IGenericRepository<Book> book, IMapper mapper)
        {
            _staffPics = staffPics;
            _books = book;
            _mapper = mapper;

            //staffPics.GetAllAsync();
            //x.GetAllAsync();
        }

        [Route("~/")]
        [Route]
        [Route("index")]
        public async Task<ActionResult> Index()
        {
            //var books = await _staffPics.GetAllAsync();
            //var results = _mapper.Map<IList<StaffPicViewModel>>(books);


            return View();
        }

        [Route("GetStaffPics")]
        public async Task<ActionResult> GetStaffPics()
        {
            var books = await _books.GetAllAsync();
            var results = _mapper.Map<IList<BookViewModel>>(books);            

            return Json(new JsonResultViewModel { Success = true, Message = "", CustomResult = results }, JsonRequestBehavior.AllowGet);
        }
    }
}
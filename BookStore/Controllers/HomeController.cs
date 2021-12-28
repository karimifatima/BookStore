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
        }

        [Route("~/")]
        [Route]
        [Route("index")]
        public async Task<ActionResult> Index()
        {
            //Test to findout if dbContext is instantiated for scope or per call
            var books = await _books.GetAllAsync();
            var staffPics = await _staffPics.GetAllAsync();

            return View();
        }

        [Route("GetStaffPics")]
        public async Task<ActionResult> GetStaffPics()
        {
            var staffPics = await _staffPics.GetAllAsync();
            var results = _mapper.Map<IList<StaffPicViewModel>>(staffPics);            

            return Json(new JsonResultViewModel { Success = true, Message = "", CustomResult = results }, JsonRequestBehavior.AllowGet);
        }
    }
}
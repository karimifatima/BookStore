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
    [RoutePrefix("Selection")]
    public class SelectionController : Controller
    {
        private readonly IGenericRepository<StaffPic> _staffPics;
        private readonly IGenericRepository<Book> _books;
        private readonly IMapper _mapper;

        public SelectionController(IGenericRepository<StaffPic> staffPics, IGenericRepository<Book> books, IMapper mapper)
        {
            _staffPics = staffPics;
            _books = books;
            _mapper = mapper;
        }

        [Route("List")]
        public ActionResult List()
        {
            return View();
        }

        [Route("AddUpdate")]
        public ActionResult AddUpdate()
        {
            return View(new CreateStaffPicViewModel());
        }

        [HttpPost]
        [Route("AddUpdate")]
        public async Task<ActionResult> AddUpdate(CreateStaffPicViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var staffPic = new StaffPic();
            _mapper.Map(vm, staffPic);

            _staffPics.Insert(staffPic);
            await _staffPics.SaveChangesAsync();

            return RedirectToAction("List");
        }

        [HttpPost]
        [Route("UpdateSelection")]
        public async Task<ActionResult> UpdateSelection(List<int> bookIds, int staffPicId)
        {
            var staffPic = await _staffPics.GetAsync(r => r.Id == staffPicId);
            _staffPics.Update(staffPic);

            if (bookIds == null)
            {
                bookIds = new List<int>();
            }

            staffPic.StaffPicBooks.RemoveAll(r => !bookIds.Contains(r.BookId));
            var newlySelectedBooks = bookIds.Where(r => !staffPic.StaffPicBooks.Any(sp => sp.BookId == r));
            if (newlySelectedBooks.Any())
                staffPic.StaffPicBooks.AddRange(newlySelectedBooks.Select(r => new StaffPicBook { BookId = r, StaffPicId = staffPicId }));

            await _staffPics.SaveChangesAsync();
            return Json(new JsonResultViewModel { Success = true });
        }

        [Route("GetAll/{filter?}")]
        public async Task<ActionResult> GetAll(string filter)
        {            
            var books =  await _books.GetAllAsync();
            var booksVm = _mapper.Map<IList<BookViewModel>>(books);

            var staffPics = string.IsNullOrWhiteSpace(filter) ? await _staffPics.GetAllAsync(): await _staffPics.GetAllAsync(r=>r.Title.Contains(filter));
            var staffPicsVm = _mapper.Map<IList<StaffPicViewModel>>(staffPics);

            return Json(new JsonResultViewModel { Success = true, Message = "", CustomResult = new { booksVm, staffPicsVm } }, JsonRequestBehavior.AllowGet);
        }
    }
}
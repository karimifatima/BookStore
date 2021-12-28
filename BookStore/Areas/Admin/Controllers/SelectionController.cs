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
        private readonly IGenericRepository<StaffPic> _staffPic;
        private readonly IMapper _mapper;

        public SelectionController(IGenericRepository<StaffPic> staffPics, IMapper mapper)
        {
            _staffPic = staffPics;
            _mapper = mapper;
        }

        [Route("List")]
        public async Task<ActionResult> List()
        {
            var staffPics = await _staffPic.GetAllAsync();
            var results = _mapper.Map<IList<StaffPicViewModel>>(staffPics);
            return View(results);
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

            _staffPic.Insert(staffPic);
            await _staffPic.SaveChangesAsync();

            return RedirectToAction("List");
        }
    }
}
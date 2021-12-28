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
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.ViewModels
{
    public class StaffPicViewModel : CreateStaffPicViewModel
    {
        public int Id { get; set; }
        public List<StaffPicBookViewModel> StaffPicBooks { get; set; }
    }

    public class CreateStaffPicViewModel
    {
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Order")]
        public int Order { get; set; }
    }
}
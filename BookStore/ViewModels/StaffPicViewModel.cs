using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.ViewModels
{
    public class StaffPicViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }

        public List<StaffPicBookViewModel> StaffPicBooks { get; set; }

    }
}
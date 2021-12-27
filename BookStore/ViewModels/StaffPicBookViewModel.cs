using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.ViewModels
{
    public class StaffPicBookViewModel
    {
        public int BookId { get; set; }
        public BookViewModel Book { get; set; }

        public int StaffPicId { get; set; }
        //public StaffPicViewModel StaffPic { get; set; }
    }
}
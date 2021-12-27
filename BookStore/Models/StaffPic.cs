using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class StaffPic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }

        public List<StaffPicBook> StaffPicBooks { get; set; }
    }
}
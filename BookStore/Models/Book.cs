using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Price { get; set; }

        //files are better to be a seperated class, my property is string just to simplify
        public string ImageName { get; set; }

        //Mostly not needed. Depends on the Logic
        public List<StaffPicBook> StaffPicBooks { get; set; }
    }
}
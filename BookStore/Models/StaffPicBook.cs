using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class StaffPicBook
    {
        [Key]
        [Column(Order = 1)]
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }

        [Key]
        [Column(Order = 2)]
        public int StaffPicId { get; set; }
        [ForeignKey("StaffPicId")]
        public StaffPic StaffPic { get; set; }
    }
}
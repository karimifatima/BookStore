using BookStore.Models;
using BookStore.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.Services.Repository
{
    public class StaffPicRepository : GenericRepository<StaffPic>
    {
        public StaffPicRepository(DatabaseContext context) : base(context)
        {
        }

        protected override IQueryable<StaffPic> GetQueryable()
        {
            return base.GetQueryable().Include(r=>r.StaffPicBooks.Select(s=>s.Book));
        }
    }
}
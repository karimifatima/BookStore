using BookStore.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class DatabaseContext : DbContext
    {
        public Guid TestId { get; set; } = Guid.NewGuid();
        public DatabaseContext() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public static DatabaseContext Create()
        {
            return new DatabaseContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(builder);

            //Seeds
            Database.SetInitializer(new BookDBInitializer());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<StaffPic> StaffPics { get; set; }
    }
}
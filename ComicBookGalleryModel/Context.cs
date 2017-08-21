﻿using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel
{
    public class Context : DbContext
    {

        public Context()
        {
            Database.SetInitializer(new DatabaseInitializer());

        }
        public DbSet<ComicBook> ComicBooks { get; set; } //using plural of class name for set is common convention

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<ComicBook>()
                .Property(cb => cb.AverageRating)
                .HasPrecision(5, 2);
        }

        private int PluralizingTableNameConvention()
        {
            throw new NotImplementedException();
        }
    }
}

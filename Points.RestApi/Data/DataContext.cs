using Microsoft.EntityFrameworkCore;
using Points.RestApi.Entities;
using Points.RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points.RestApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Point> Points { get; set; }
        public DbSet<PointsListTitle> Titles { get; set; }
        public DbSet<PointsList> PointsList { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PointsListTitle>()
            .HasMany(e => e.PointsLists)
            .WithOne();
            //.OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}

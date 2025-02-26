using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Movie 1", Director = "Luis 1", Year = 2022 },
                new Movie { Id = 2, Title = "Movie 2", Director = "Luis 2", Year = 2023 },
                new Movie { Id = 3, Title = "Movie 3", Director = "Luis 3", Year = 2024 }
            );

            
        }



    }
}

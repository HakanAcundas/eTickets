using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_MovieModel>().HasKey(am => new
            {
                am.ActorID,
                am.MovieID
            });

            modelBuilder.Entity<Actor_MovieModel>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m =>
            m.MovieID);
            modelBuilder.Entity<Actor_MovieModel>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m =>
            m.ActorID);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ActorModel> TBL_ACTORS { get; set; }
        public DbSet<MovieModel> TBL_MOVIES { get; set; }
        public DbSet<Actor_MovieModel> TBL_ACTORS_MOVIES { get; set; }
        public DbSet<CinemaModel> TBL_CINEMAS { get; set; }
        public DbSet<ProducerModel> TBL_PRODUCERS { get; set; }
    }
}

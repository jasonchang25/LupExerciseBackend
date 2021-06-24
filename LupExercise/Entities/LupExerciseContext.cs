using LupExercise.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupExercise.Entities
{
    public partial class LupExerciseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=LupExercise.db");
        //protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer("Server=LocalHost\\SQLExpress;database=LupExercise;Integrated Security=true;");

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.EventName).IsRequired();
                entity.Property(e => e.EventDescription).IsRequired();
            });

            // Add some dummy data to start
            var events = new Event[]
            {
                new Event { EventId = 1, EventName = "Christmas Party", EventDescription = "Christmas Party stuff", EventTimezone = "GMT+10", StartDate = new DateTime(2021,6,25), EndDate = new DateTime(2021,6,27), CreatedDate = DateTime.UtcNow, ModifiedDate = DateTime.UtcNow},
                new Event { EventId = 2, EventName = "Event 2", EventDescription = "Event 2", EventTimezone = "GMT+8", StartDate = new DateTime(2021,5,13), EndDate = new DateTime(2021,5,15), CreatedDate = DateTime.UtcNow, ModifiedDate = DateTime.UtcNow},
                new Event { EventId = 3, EventName = "Event 3", EventDescription = "Event 3", EventTimezone = "GMT+8", StartDate = new DateTime(2021,7,11), EndDate = new DateTime(2021,11,7), CreatedDate = DateTime.UtcNow, ModifiedDate = DateTime.UtcNow},
            };


            modelBuilder.Entity<Event>().HasData(events);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using Microsoft.EntityFrameworkCore;
using System;


namespace DreamJournal.Models
{
  public class DreamJournalContext : DbContext
  {
    public DreamJournalContext(DbContextOptions<DreamJournalContext> options)
        : base(options)
    {
    }

    public DbSet<Dream> Dreams { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Dream>()
        .HasData(
          new Dream { DreamId = 1, Title = "Example", UserName = "Frederick Ernest", Date = new DateTime (2020, 1, 1), Body = "I dreamt I was floating down a river in Thailand, that was forested, and had settlements on the side of the river."}
        );
      builder.Entity<User>()
      .HasData(
        new User { UserId = 1, UserName = "Frederick Ernest"}
      );
    }
    }
}
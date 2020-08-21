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

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Dream>()
        .HasData(
          new Dream { DreamId = 1, Title = "Polar Bear in Thailand", Body = "I dreamt I was floating down a river in Thailand, that was forested, and had settlements on the side of the river."}
        );
    }
    }
}
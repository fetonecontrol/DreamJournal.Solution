using System;

namespace DreamJournal.Models
{
  public class Dream
    {
      public int DreamId { get; set; }
      public string Title { get; set; }
      public DateTime Date { get; set; }
      public string UserName { get; set; }
      public string Body { get; set; }

    }
}
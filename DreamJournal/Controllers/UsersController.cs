using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DreamJournal.Models;

namespace DreamJournal.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private DreamJournalContext _db;

    public UsersController(DreamJournalContext db)
    {
      _db = db;
    }

    [HttpGet("Page")]
    public IActionResult GetAll([FromQuery] UrlQuery urlQuery)
    {
      var validUrlQuery = new UrlQuery(urlQuery.PageNumber, urlQuery.PageSize);
      var pagedData = _db.Users
        .OrderBy(thing => thing.DreamId)
        .Skip((validUrlQuery.PageNumber - 1) * validUrlQuery.PageSize)
        .Take(validUrlQuery.PageSize);
      return Ok(pagedData);
    }

    // GET api/Users  
    [HttpGet]
    public ActionResult<IEnumerable<Dream>> Get(string title, string body)
    {
      var query = _db.Users.AsQueryable();
      if (title != null)
      {
        query = query.Where(entry => entry.Title == title);
      }
      if (body != null)
      {
        query = query.Where(entry => entry.Body == body);
      }

      return query.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Dream> Get(int id)
    {
        return _db.Users.FirstOrDefault(entry => entry.DreamId == id);
    }

    // PUT api/Users/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Dream dream)
    {
        dream.DreamId = id;
        _db.Entry(dream).State = EntityState.Modified;
        _db.SaveChanges();
    }

    // POST api/Users
    [HttpPost]
    public void Post([FromBody] Dream dream)
    {
      _db.Users.Add(dream);
      _db.SaveChanges();
    }
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var dreamToDelete = _db.Users.FirstOrDefault(entry => entry.DreamId == id);
      _db.Users.Remove(dreamToDelete);
      _db.SaveChanges();
    }
  }
}
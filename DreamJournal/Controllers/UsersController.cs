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
        .OrderBy(thing => thing.UserId)
        .Skip((validUrlQuery.PageNumber - 1) * validUrlQuery.PageSize)
        .Take(validUrlQuery.PageSize);
      return Ok(pagedData);
    }

    // GET api/Users  
    [HttpGet]
    public ActionResult<IEnumerable<User>> Get(string userName)
    {
      var query = _db.Users.AsQueryable();
      if (userName != null)
      {
        query = query.Where(entry => entry.UserName == userName);
      }

      return query.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
        return _db.Users.FirstOrDefault(entry => entry.UserId == id);
    }

    // PUT api/Users/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] User user)
    {
        user.UserId = id;
        _db.Entry(user).State = EntityState.Modified;
        _db.SaveChanges();
    }

    // POST api/Users
    [HttpPost]
    public void Post([FromBody] User user)
    {
      _db.Users.Add(user);
      _db.SaveChanges();
    }
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var userToDelete = _db.Users.FirstOrDefault(entry => entry.UserId == id);
      _db.Users.Remove(userToDelete);
      _db.SaveChanges();
    }
  }
}
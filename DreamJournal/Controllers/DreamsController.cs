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
  public class DreamsController : ControllerBase
  {
    private DreamJournalContext _db;

    public DreamsController(DreamJournalContext db)
    {
      _db = db;
    }

    [HttpGet("Page")]
    public IActionResult GetAll([FromQuery] UrlQuery urlQuery)
    {
      var validUrlQuery = new UrlQuery(urlQuery.PageNumber, urlQuery.PageSize);
      var pagedData = _db.Dreams
        .OrderBy(thing => thing.DreamId)
        .Skip((validUrlQuery.PageNumber - 1) * validUrlQuery.PageSize)
        .Take(validUrlQuery.PageSize);
      return Ok(pagedData);
    }

    // GET api/Dreams  
    [HttpGet]
    public ActionResult<IEnumerable<Dream>> Get(string title, string body)
    {
      var query = _db.Dreams.AsQueryable();
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
    // [HttpGet("AverageSpan")]
    // public ActionResult<int> AverageSpan(string name, string country, string city, string architect)
    // {
    //   var query = _db.Dreams.AsQueryable();

    //   if (name != null)
    //   {
    //     query = query.Where(entry => entry.Name == name);
    //   }
    //   if (country != null)
    //   {
    //     query = query.Where(entry => entry.Country == country);
    //   }
    //   if (city != null)
    //   {
    //     query = query.Where(entry => entry.City == city);
    //   }
    //   if (architect != null)
    //   {
    //     query = query.Where(entry => entry.Architect == architect);
    //   }

    //   List<Dream> listOfQuery = query.ToList();
    //   int count = 0; 

    //   for (int i = 0; i < listOfQuery.Count; i++)
    //   {
    //     count += listOfQuery[i].Span;
    //   }
    //   int average = count/listOfQuery.Count;
      
    //   return average;
    // }


    [HttpGet("{id}")]
    public ActionResult<Dream> Get(int id)
    {
        return _db.Dreams.FirstOrDefault(entry => entry.DreamId == id);
    }

    // PUT api/Dreams/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Dream dream)
    {
        dream.DreamId = id;
        _db.Entry(dream).State = EntityState.Modified;
        _db.SaveChanges();
    }

    // POST api/Dreams
    [HttpPost]
    public void Post([FromBody] Dream dream)
    {
      _db.Dreams.Add(dream);
      _db.SaveChanges();
    }
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var dreamToDelete = _db.Dreams.FirstOrDefault(entry => entry.DreamId == id);
      _db.Dreams.Remove(dreamToDelete);
      _db.SaveChanges();
    }
  }
}
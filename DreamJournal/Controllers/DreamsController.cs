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
  public class BridgesController : ControllerBase
  {
    private DreamJournalContext _db;

    public BridgesController(DreamJournalContext db)
    {
      _db = db;
    }

    [HttpGet("Page")]
    public IActionResult GetAll([FromQuery] UrlQuery urlQuery)
    {
      var validUrlQuery = new UrlQuery(urlQuery.PageNumber, urlQuery.PageSize);
      var pagedData = _db.Bridges
        .OrderBy(thing => thing.BridgeId)
        .Skip((validUrlQuery.PageNumber - 1) * validUrlQuery.PageSize)
        .Take(validUrlQuery.PageSize);
      return Ok(pagedData);
    }

    // GET api/Bridges  
    [HttpGet]
    public ActionResult<IEnumerable<Dream>> Get(string title, string story)
    {
      var query = _db.Dreams.AsQueryable();
      if (title != null)
      {
        query = query.Where(entry => entry.Id == id);
      }
      if (story != null)
      {
        query = query.Where(entry => entry.Story == story);
      }

      return query.ToList();
    }
    // [HttpGet("AverageSpan")]
    // public ActionResult<int> AverageSpan(string name, string country, string city, string architect)
    // {
    //   var query = _db.Bridges.AsQueryable();

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

    //   List<Bridge> listOfQuery = query.ToList();
    //   int count = 0; 

    //   for (int i = 0; i < listOfQuery.Count; i++)
    //   {
    //     count += listOfQuery[i].Span;
    //   }
    //   int average = count/listOfQuery.Count;
      
    //   return average;
    // }


    [HttpGet("{id}")]
    public ActionResult<Bridge> Get(int id)
    {
        return _db.Bridges.FirstOrDefault(entry => entry.BridgeId == id);
    }

    // PUT api/Bridges/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Bridge bridge)
    {
        bridge.BridgeId = id;
        _db.Entry(bridge).State = EntityState.Modified;
        _db.SaveChanges();
    }

    // POST api/Bridges
    [HttpPost]
    public void Post([FromBody] Bridge bridge)
    {
      _db.Bridges.Add(bridge);
      _db.SaveChanges();
    }
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var bridgeToDelete = _db.Bridges.FirstOrDefault(entry => entry.BridgeId == id);
      _db.Bridges.Remove(bridgeToDelete);
      _db.SaveChanges();
    }
  }
}
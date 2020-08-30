using DreamJournal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;


namespace DreamJournal.Models
{
    public class UrlQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public UrlQuery()
        {
            this.PageNumber = 1;
            this.PageSize = 2;
        }

        public UrlQuery(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 2 ? 2 : pageSize;
        }
    }
}
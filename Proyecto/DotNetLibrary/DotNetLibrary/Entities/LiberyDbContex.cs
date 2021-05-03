using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DotNetLibrary.Entities
{
    public class LiberyDbContex : DbContext
    {
        public LiberyDbContex(DbContextOptions options) : base(options)
        {

        }

        protected LiberyDbContex() 
        {

        }

        public virtual DbSet<BookItem> Books { get; set; } 
        //Tables
    }
}

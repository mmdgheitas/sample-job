using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WORK_SAMPLE.Models
{
    public class db : DbContext
    {
        public db() : base("sj")
        { }
        public DbSet<human> human { get; set; }
        public DbSet<S> admin { get; set; }
    }
}
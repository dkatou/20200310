using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api1Models.Models;

namespace api1Models.Data
{
    public class api1Context : DbContext
    {
        public api1Context (DbContextOptions<api1Context> options)
            : base(options)
        {
        }

        public DbSet<api1Models.Models.Item> Item { get; set; }
    }
}

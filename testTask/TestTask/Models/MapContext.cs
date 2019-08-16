using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestTask.Models
{
    public class MapContext : DbContext
    {
        public MapContext(DbContextOptions<MapContext> options) : base(options)
        {
        }

        public DbSet<Map> Maps { get; set; }
    }
}

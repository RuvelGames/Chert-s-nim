using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Chert_s_nim.Models
{
    public class EngineContext : DbContext
    {
        public DbSet<EngineData> Engines { get; set; } = null!;
        public EngineContext(DbContextOptions<EngineContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
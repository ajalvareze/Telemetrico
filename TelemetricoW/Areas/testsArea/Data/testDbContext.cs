using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelemetricoW.Areas.testsArea.Models;

namespace TelemetricoW.Areas.testsArea.Data
{
    public class TestDbContext  : DbContext
    {
        // When used with ASP.net core, add these lines to Startup.cs
        //   var connectionString = Configuration.GetConnectionString("testDbContext");
        //   services.AddEntityFrameworkNpgsql().AddDbContext<BlogContext>(options => options.UseNpgsql(connectionString));
        // and add this to appSettings.json
        // "ConnectionStrings": { "testDbContext": "Server=localhost;Database=postgres" }

        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }

        public DbSet<Usuario> usuarios { get; set; }
    }
}

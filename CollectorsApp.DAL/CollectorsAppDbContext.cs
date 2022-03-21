using CollectorsApp.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsApp.DAL
{

    public class CollectorsAppDbContext : IdentityDbContext<User>
    {
        public CollectorsAppDbContext(DbContextOptions<CollectorsAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Collectible> Collection { get; set; }
    }
}

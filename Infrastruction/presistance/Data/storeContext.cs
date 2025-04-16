using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace presistance.Data
{
    public class storeContext:DbContext
    {
        internal object productType;

        public storeContext(DbContextOptions<storeContext> options):base(options) { 
        } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(storeContext).Assembly);
        }

        #region DB set
        public DbSet<Product> products { get; set; }
        public DbSet<productBrand> brands { get; set; }
        public DbSet<productType> types { get; set; }

        #endregion
    }
}

using NetFundamentals.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFundamentals.Repository
{
    public class ChinookContext : DbContext
    {
        public ChinookContext(): base("NetFundamentals")
        {
            Database.SetInitializer<ChinookContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Customer> Customer { get; set; }
    }
}

using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DoiBongDBContext:DbContext
    {
        public DoiBongDBContext():base("DoiBongConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<CauThu> CauThus { get; set; }
        public DbSet<DoiBong> DoiBongs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

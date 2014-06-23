using System.Data.Entity;
using HomeAccounting.UI.Entities;

namespace HomeAccounting.UI.Concrete
{
    public class HaContext : DbContext
    {
        //TODO: Add Category        
        //TODO: Link DB to Cloud (i.e. WinFolder)
        public IDbSet<Transaction> Transactions { get; set; }
        public IDbSet<Exchange> Exchanges { get; set; }
        public IDbSet<Category> Categories { get; set; }

        public HaContext()
            : base("HomeAccounting") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<HaContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}

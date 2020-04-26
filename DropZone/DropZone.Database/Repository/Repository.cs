using System.Data.Entity;

namespace DropZone.Database.Repository
{
    public partial class Repository : IRepository
    {
        private DropZoneContext _context;

        public Repository(DropZoneContext context)
        {
            _context = context;
        }

        public DbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}

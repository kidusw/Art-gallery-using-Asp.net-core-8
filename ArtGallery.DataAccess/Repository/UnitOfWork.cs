using ArtGallery.DataAccess.Data;
using ArtGallery.DataAccess.Repository.IRepository;

namespace ArtGallery.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }

        public IArtRepository Art { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Art = new ArtRepository(_db);
        }
        public ICategoryRepository CategoryRepository { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

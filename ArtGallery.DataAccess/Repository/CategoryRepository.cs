using ArtGallery.DataAccess.Data;
using ArtGallery.DataAccess.Repository.IRepository;
using ArtGallery.Models;

namespace ArtGallery.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category obj)
        {
            _db.categories.Update(obj);
        }
    }
}

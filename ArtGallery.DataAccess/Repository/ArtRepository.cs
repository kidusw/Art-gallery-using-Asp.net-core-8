using ArtGallery.DataAccess.Data;
using ArtGallery.DataAccess.Repository.IRepository;
using ArtGallery.Models;

namespace ArtGallery.DataAccess.Repository
{
	public class ArtRepository : Repository<Art>, IArtRepository
	{
		private ApplicationDbContext _db;

		public ArtRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}


		public void Update(Art obj)
		{
			var objFromDb = _db.arts.FirstOrDefault(u => u.Id == obj.Id);
			if (objFromDb != null)
			{
				objFromDb.Title = obj.Title;
				objFromDb.Artist = obj.Artist;
				objFromDb.Description = obj.Description;
				objFromDb.CategoryId = obj.CategoryId;
				if (objFromDb.Imageurl != null)
				{
					objFromDb.Imageurl = obj.Imageurl;
				}
			}
		}
	}
}

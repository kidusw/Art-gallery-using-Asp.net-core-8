using ArtGallery.Models;

namespace ArtGallery.DataAccess.Repository.IRepository
{
    public interface IArtRepository : IRepository<Art>
    {
        void Update(Art obj);

    }
}

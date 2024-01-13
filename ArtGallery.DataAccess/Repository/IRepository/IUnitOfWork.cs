namespace ArtGallery.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IArtRepository Art { get; }
        void Save();
    }
}

namespace TicketSystem.Web.Data.Common
{
    using System.Linq;

    public interface IRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Create(TEntity entity);

        void SaveChanges();
    }
}

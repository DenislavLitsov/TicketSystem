namespace TicketSystem.Web.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using Microsoft.EntityFrameworkCore;

    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IBaseModel
    {
        private ApplicationDBContext applicationDBContext;

        private DbSet<TEntity> entities;

        public Repository(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
            this.entities = this.applicationDBContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.entities;
        }

        public void Create(TEntity entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            this.entities.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            this.entities.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            this.entities.Update(entity);
        }

        public void SaveChanges()
        {
            this.applicationDBContext.SaveChanges();
        }
    }
}

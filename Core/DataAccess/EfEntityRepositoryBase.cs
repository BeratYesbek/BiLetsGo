using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
    {
        public TEntity Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return addedEntity.Entity;
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;

                var entry = context.Entry(entity);
                var properties = typeof(TEntity).GetProperties();
                foreach (var property in properties)
                {
                    if (property.GetValue(entity, null) == null && property.GetType() != typeof(IFormFile))
                    {
                        entry.Property(property.Name).IsModified = false;
                    }
                }

                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                var result = context.Set<TEntity>().SingleOrDefault(filter);
                return result;
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
        
             var result = filter == null
              ? context.Set<TEntity>().ToList()
              : context.Set<TEntity>().Where(filter).ToList();
              return result;
            }
        }

        public List<TEntity> GetAllIncluded(params Expression<Func<TEntity, object>>[] including)
        {
            using (TContext context = new TContext())
            {

                var include = context.Set<TEntity>().AsQueryable();
                including.ToList().ForEach(item =>
                {
                    include = include.Include(item);
                });
                return include.ToList();
            }
        }
    }
}

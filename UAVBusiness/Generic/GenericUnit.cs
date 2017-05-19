using UAVData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UAVBusiness.Generic;

namespace UAVBusiness.Generic
{
    public class GenericUnit<TEntity> : ClsDispose where TEntity : class
    {
        internal UAVEntities context;
        internal DbSet<TEntity> dbSet;

        public GenericUnit(UAVEntities Context)
        {
            context = Context;
            dbSet = context.Set<TEntity>();
        }

        public virtual TEntity Insert(TEntity Entity)
        {
            dbSet.Add(Entity);
            context.SaveChanges();

            return Entity;
        }

        public virtual void InsertAll(List<TEntity> lstEntity)
        {
            dbSet.AddRange(lstEntity);
            context.SaveChanges();
        }

        public virtual TEntity Update(TEntity entityToUpdate)
        {
            try
            {

                dbSet.Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = EntityState.Modified;
                context.SaveChanges();
                return entityToUpdate;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        continue;
                    }
                }
                return null;

            }
        }

        public virtual void Delete(TEntity Entity)
        {
            if (context.Entry(Entity).State == EntityState.Detached)
                dbSet.Attach(Entity);
            dbSet.Remove(Entity);
            context.SaveChanges();
        }

        public virtual void Delete(int Id)
        {
            TEntity entity = dbSet.Find(Id);
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public virtual void DeleteAll(List<TEntity> lstEntity)
        {
            dbSet.RemoveRange(lstEntity);
            context.SaveChanges();
        }

       

        public virtual TEntity GetById(long id)
        {
            return dbSet.Find(id);
        }



        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }




    }
}

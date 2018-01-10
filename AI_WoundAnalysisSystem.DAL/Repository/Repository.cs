using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace AI_WoundAnalysisSystem.DAL.Repository
{
    /// <summary>
    /// The data repository
    /// </summary>
    /// <typeparam name="TEntity">an entity class (only)</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// the context
        /// </summary>
        private AI_WoundAnalysisSystemContext context;

        /// <summary>
        /// the entity set
        /// </summary>
        private DbSet<TEntity> entitySet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class
        /// </summary>
        /// <param name="context">the context</param>
        public Repository(AI_WoundAnalysisSystemContext context)
        {
            this.context = context;
            this.entitySet = context.Set<TEntity>();
        }

        /// <summary>
        /// Gets the entities as query for further manipulation
        /// </summary>
        /// <param name="totalCount">returns total count of entities in the result set</param>
        /// <param name="filter">where clause</param>
        /// <param name="orderBy">order by clause</param>
        /// <param name="enablePaging" value="false">true if paging must be enabled (will work only for ordered queries)</param>
        /// <param name="countPerPage" value="10">number of entities per page</param>
        /// <param name="includeProperties">include properties</param>
        /// <returns>matching entities as a query</returns>
        public IQueryable<TEntity> GetQuery(
                                out int totalCount,
                                Expression<Func<TEntity, bool>> filter = null,
                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                bool enablePaging = false,
                                int curPage = 0,
                                int countPerPage = 10,
                                string includeProperties = "")
        {
            IQueryable<TEntity> query = this.entitySet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            totalCount = query.Count();

            if (orderBy != null)
            {
                if (enablePaging)
                {
                    return orderBy(query).Skip(curPage * countPerPage).Take(countPerPage);
                }
                else
                {
                    return orderBy(query);
                }
            }
            else
            {
                return query;
            }
        }
        /// <summary>
        /// Gets the entities 
        /// </summary>
        /// <param name="totalCount">returns total count of entities in the result set</param>
        /// <param name="filter">where clause</param>
        /// <param name="orderBy">order by clause</param>
        /// <param name="enablePaging" value="false">true if paging must be enabled (will work only for ordered queries)</param>
        /// <param name="countPerPage" value="10">number of entities per page</param>
        /// <param name="includeProperties">include properties</param>
        /// <returns>matching entities</returns>
        public IEnumerable<TEntity> Get(
                                out int totalCount,
                                Expression<Func<TEntity, bool>> filter = null,
                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                bool enablePaging = false,
                                int curPage = 0,
                                int countPerPage = 10,
                                string includeProperties = "")
        {
            return GetQuery(out totalCount, filter, orderBy, enablePaging, curPage, countPerPage, includeProperties).ToList();
        }

        /// <summary>
        /// Gets the entities 
        /// </summary>
        /// <param name="filter">where clause</param>
        /// <param name="includeProperties">include properties</param>
        /// <returns></returns>
        public IEnumerable<TEntity> Get(
                                Expression<Func<TEntity, bool>> filter,
                                string includeProperties = "")
        {
            int total;

            return Get(out total, filter, null, false, 0, 0, includeProperties);
        }

        /// <summary>
        /// Gets the entities as a query for further manipulation
        /// </summary>
        /// <param name="filter">where clause</param>
        /// <param name="includeProperties">include properties</param>
        /// <returns></returns>
        public IQueryable<TEntity> GetQuery(
                                Expression<Func<TEntity, bool>> filter,
                                string includeProperties = "")
        {
            int total;

            return GetQuery(out total, filter, null, false, 0, 0, includeProperties);
        }

        /// <summary>
        /// Gets entity by id
        /// </summary>
        /// <param name="id">the entity id</param>
        /// <returns>the entity</returns>
        public TEntity GetByID(object id)
        {
            return this.entitySet.Find(id);
        }

        /// <summary>
        /// Inserts entity into the database
        /// </summary>
        /// <param name="entity">the entity</param>
        public void Insert(TEntity entity)
        {
            this.entitySet.Add(entity);
        }

        /// <summary>
        /// Deletes an entity by id
        /// </summary>
        /// <param name="id">the entity to find and delete</param>
        public void Delete(object id)
        {
            try
            {
                TEntity entityToDelete = this.entitySet.Find(id);
                this.Delete(entityToDelete);
            }
            catch (System.AggregateException) { }
        }

        /// <summary>
        /// Deletes input entity
        /// </summary>
        /// <param name="entityToDelete">entity to delete</param>
        public void Delete(TEntity entityToDelete)
        {
            try
            {
                if (this.context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    this.entitySet.Attach(entityToDelete);
                }

                this.entitySet.Remove(entityToDelete);
            }
            catch (System.AggregateException) { }
        }

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="entityToUpdate">entity to update</param>
        public void Update(TEntity entityToUpdate)
        {
            ////this.entitySet.Attach(entityToUpdate);
            ////this.context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="entityToUpdate">entity to update</param>
        public void UpdateSingle(TEntity entityToUpdate)
        {
            this.entitySet.Attach(entityToUpdate);
            this.context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        /// <summary>
        /// Gets entities using raw SQL
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <param name="parameters">query parameters</param>
        /// <returns>list of matching entities</returns>
        public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
        {
            return this.entitySet.SqlQuery(query, parameters).ToList();
        }

        /// <summary>
        /// Execute an insert, update or delete query
        /// </summary>
        /// <param name="query">DDL query</param>
        /// <param name="parameters">the query parameters</param>
        /// <returns>the rows affected</returns>
        public int ExecuteNonQueryWithRawSql(string query, params object[] parameters)
        {
            return this.context.Database.ExecuteSqlCommand(query, parameters);
        }
    }
}


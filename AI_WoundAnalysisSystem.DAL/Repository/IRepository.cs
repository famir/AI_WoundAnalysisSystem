using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AI_WoundAnalysisSystem.DAL.Repository
{

    /// <summary>
    /// Interface to the data repository
    /// </summary>
    /// <typeparam name="TEntity">an entity class (only)</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets the entities 
        /// </summary>
        /// <param name="totalCount">returns total count of entities in the result set</param>
        /// <param name="filter">where clause</param>
        /// <param name="orderBy">order by clause</param>
        /// <param name="enablePaging" value="false">true if paging must be enabled (will work only for ordered queries)</param>
        /// <param name="countPerPage" value="10">number of entities per page</param>
        /// <param name="curPage">current page</param>
        /// <param name="includeProperties">include properties</param>
        /// <returns>matching entities</returns>
        IEnumerable<TEntity> Get(
                                out int totalCount,
                                Expression<Func<TEntity, bool>> filter = null,
                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                bool enablePaging = false,
                                int curPage = 0,
                                int countPerPage = 10,
                                string includeProperties = "");

        /// <summary>
        /// Gets the entities 
        /// </summary>
        /// <param name="totalCount">returns total count of entities in the result set</param>
        /// <param name="filter">where clause</param>
        /// <param name="orderBy">order by clause</param>
        /// <param name="enablePaging" value="false">true if paging must be enabled (will work only for ordered queries)</param>
        /// <param name="curPage">current page</param>
        /// <param name="countPerPage" value="10">number of entities per page</param>
        /// <param name="includeProperties">include properties</param>
        /// <returns>matching entities</returns>
        IQueryable<TEntity> GetQuery(
                                out int totalCount,
                                Expression<Func<TEntity, bool>> filter = null,
                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                bool enablePaging = false,
                                int curPage = 0,
                                int countPerPage = 10,
                                string includeProperties = "");

        /// <summary>
        /// Gets the entities 
        /// </summary>
        /// <param name="filter">where clause</param>
        /// <param name="includeProperties">include properties</param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(
                                Expression<Func<TEntity, bool>> filter,
                                string includeProperties = "");

        /// <summary>
        /// Gets the entities as a query for further manipulation
        /// </summary>
        /// <param name="filter">where clause</param>
        /// <param name="includeProperties">include properties</param>
        /// <returns></returns>
        IQueryable<TEntity> GetQuery(
                                Expression<Func<TEntity, bool>> filter,
                                string includeProperties = "");

        /// <summary>
        /// Gets entity by id
        /// </summary>
        /// <param name="id">the entity id</param>
        /// <returns>the entity</returns>
        TEntity GetByID(object id);

        /// <summary>
        /// Inserts entity into the database
        /// </summary>
        /// <param name="entity">the entity</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Deletes an entity by id
        /// </summary>
        /// <param name="id">the entity to find and delete</param>
        void Delete(object id);

        /// <summary>
        /// Deletes input entity
        /// </summary>
        /// <param name="entityToDelete">entity to delete</param>
        void Delete(TEntity entityToDelete);

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="entityToUpdate">entity to update</param>
        void Update(TEntity entityToUpdate);

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="entityToUpdate">entity to update</param>
        void UpdateSingle(TEntity entityToUpdate);

        /// <summary>
        /// Gets entities using raw SQL
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <param name="parameters">query parameters</param>
        /// <returns>list of matching entities</returns>
        IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters);

        /// <summary>
        /// Execute an insert, update or delete query
        /// </summary>
        /// <param name="query">DDL query</param>
        /// <param name="parameters">the query parameters</param>
        /// <returns>the rows affected</returns>
        int ExecuteNonQueryWithRawSql(string query, params object[] parameters);
    }
}

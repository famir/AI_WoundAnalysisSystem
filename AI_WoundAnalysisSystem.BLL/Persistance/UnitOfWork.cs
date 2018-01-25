
using AI_WoundAnalysisSystem.BLL.Interface;
using AI_WoundAnalysisSystem.DAL;
using AI_WoundAnalysisSystem.DAL.Repository;
using AI_WoundAnalysisSystem.DTO;
using System;

namespace AI_WoundAnalysisSystem.BLL.Persistance
{
    /// <summary>
    /// Represents a unit of work
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// the data context
        /// </summary>
        private AI_WoundAnalysisSystemContext context = new AI_WoundAnalysisSystemContext();

        #region declarations

        /// <summary>
        /// the Users repository
        /// </summary>
        private IRepository<Users> usersRepository;

        /// <summary>
        /// the wound repository
        /// </summary>
        private IRepository<Wound> woundRepository;

        #endregion

        /// <summary>
        /// true if object is disposed
        /// </summary>
        private bool disposed = false;

        #region definitions

        /// <summary>
        /// Gets user details repository
        /// </summary>
        public IRepository<Users> UsersRepository
        {
            get
            {
                if (this.usersRepository == null)
                {
                    this.usersRepository = new Repository<Users>(this.context);
                }

                return this.usersRepository;
            }
        }

        /// <summary>
        /// Gets WoundRepository details repository
        /// </summary>
        public IRepository<Wound> WoundRepository
        {
            get
            {
                if (this.woundRepository == null)
                {
                    this.woundRepository = new Repository<Wound>(this.context);
                }

                return this.woundRepository;
            }
        }
        #endregion

        /// <summary>
        /// Saves changes
        /// </summary>
        public void Save()
        {
            this.context.SaveChanges();
        }

        /// <summary>
        /// Disposes the unit of work
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the unit of work
        /// </summary>
        /// <param name="disposing">true if disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }

            this.disposed = true;
        }
    }
}



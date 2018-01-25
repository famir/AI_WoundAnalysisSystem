
using AI_WoundAnalysisSystem.DAL.Repository;
using AI_WoundAnalysisSystem.DTO;


namespace AI_WoundAnalysisSystem.BLL.Interface
{
    /// <summary>
    /// Represents the interface to a unit of work
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets the Users repository
        /// </summary>
        IRepository<Users> UsersRepository { get; }

        /// <summary>
        /// Gets WoundRepository details repository
        /// </summary>
        IRepository<Wound> WoundRepository { get; }

        /// <summary>
        /// Gets Zeiterfassung details repository
        /// </summary>
        //IRepository<Zeiterfassung> ZeiterfassungRepository { get; }

        /// <summary>
        /// Saves changes in the unit of work
        /// </summary>
        void Save();
    }
}


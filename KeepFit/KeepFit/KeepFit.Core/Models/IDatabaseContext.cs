using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepFit.Core.Models
{
    public interface IDatabaseContext : IDisposable
    {
        /// <summary>
        /// Saves all changes made in this context to the underlying database. 
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        int SaveChanges();

        /// <summary>
        /// Asynchronously saves all changes made in this context to the underlying database. 
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Attaches the entity to the context, optionally saving all changes made in this context to the underlying database (if <paramref name="saveChanges"/> is <value>true</value>). 
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database (0, if <paramref name="saveChanges"/> is <value>false</value>).
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        int Attach<T>(T entity, bool saveChanges = false) where T : AuditableEntity;

        /// <summary>
        /// Returns a DbSet instance for access to entities of the given type in the context
        /// </summary>
        /// <remarks>
        /// See the DbSet class for more details. 
        /// </remarks>
        /// <typeparam name="TEntity">The type entity for which a set should be returned. </typeparam>
        /// <returns>
        /// A set for the given entity type.
        /// </returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}

using System;

namespace KeepFit.Core.Domain.Entity
{
    /// <summary>
    /// Provides auditing of creation and updating information for an entity.
    /// </summary>
    public abstract class AuditableEntity : EntityBase, IAuditable
    {
        /// <summary>
        /// Id of the user who created this entity.
        /// </summary>
        public int CreatedById { get; set; }

        /// <summary>
        /// Date and time this entity was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Id of the user who last updated this entity.
        /// </summary>
        public int LastUpdatedById { get; set; }

        /// <summary>
        /// Date and time this entity was last updated.
        /// </summary>
        public DateTime LastUpdatedDate { get; set; }
    }
}

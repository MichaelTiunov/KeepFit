using System;

namespace KeepFit.Core.Domain.Entity
{
    public interface IAuditable
    {
        /// <summary>
        /// Id of the user who created this object.
        /// </summary>
        int CreatedById { get; }

        /// <summary>
        /// Date and time this object was created.
        /// </summary>
        DateTime CreatedDate { get; }

        /// <summary>
        /// Id of the user who last updated this object.
        /// </summary>
        int LastUpdatedById { get; }

        /// <summary>
        /// Date and time this object was last updated.
        /// </summary>
        DateTime LastUpdatedDate { get; }
    }
}

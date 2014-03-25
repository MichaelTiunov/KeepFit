using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepFit.Core.Models
{
    public class ExtendedContext : DbContext, IDatabaseContext
    {
        protected IIdentityAuditProvider IdentityAuditProvider { get; set; }

        public ExtendedContext(string nameOrConnectionString, IIdentityAuditProvider identityAuditProvider)
            : base(nameOrConnectionString)
        {
            IdentityAuditProvider = identityAuditProvider;
        }

        public override int SaveChanges()
        {
            var entitiesWithOverriddenState = SetAuditInfo();

            var res = 0;

            try
            {
                res = base.SaveChanges();
                foreach (var auditableEntity in entitiesWithOverriddenState)
                {
                    //We've just synchronized domain model and database, no need to override entity states anymore
                    auditableEntity.EntityState = null;
                }
            }
            catch (DbEntityValidationException e)
            {
                var sb = new StringBuilder();

                foreach (var failure in e.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), e
                    ); // Add the original exception as the innerException
            }

            return res;
        }

        public async override Task<int> SaveChangesAsync()
        {
            var entitiesWithOverriddenState = SetAuditInfo();

            var res = 0;

            try
            {
                res = await base.SaveChangesAsync();
                foreach (var auditableEntity in entitiesWithOverriddenState)
                {
                    //We've just synchronized domain model and database, no need to override entity states anymore
                    auditableEntity.EntityState = null;
                }
            }
            catch (DbEntityValidationException e)
            {
                //TODO: LOGME
            }

            return res;
        }

        public int Attach<T>(T entity, bool saveChanges = false) where T : AuditableEntity
        {
            if (entity.EntityState == EntityState.Added)
            {
                Set<T>().Add(entity);
            }
            else
            {
                Set<T>().Attach(entity);
            }

            //SetAuditInfo();
            if (saveChanges) return /*base.*/SaveChanges();
            return 0;
        }

        private IEnumerable<IEntity> SetAuditInfo()
        {
            var entitiesWithOverriddenState = new List<IEntity>();
            foreach (var entry in ChangeTracker.Entries<IEntity>())
            {
                var businessEntity = entry.Entity;
                if (businessEntity.EntityState.HasValue)
                {
                    entry.State = (System.Data.Entity.EntityState) businessEntity.EntityState.Value;
                    entitiesWithOverriddenState.Add(businessEntity);
                }

                if (entry.State == System.Data.Entity.EntityState.Added ||
                    entry.State == System.Data.Entity.EntityState.Modified)
                {
                    var auditableEntry =
                        ChangeTracker.Entries<AuditableEntity>().SingleOrDefault(e => object.ReferenceEquals(e.Entity, entry.Entity));
                    if (auditableEntry != null)
                    {
                        AttachAuditFields(auditableEntry);
                    }
                }
            }
            return entitiesWithOverriddenState;
        }

        private void AttachAuditFields(DbEntityEntry<AuditableEntity> entry)
        {
            var auditableEntity = entry.Entity;

            var currentUser = String.Empty;

            if (IdentityAuditProvider != null)
            {
                currentUser = IdentityAuditProvider.PrincipalIdentityName;
            }

            var now = DateTime.UtcNow;

            auditableEntity.UpdatedDate = now;
            auditableEntity.UpdatedBy = currentUser;

            if (entry.State == System.Data.Entity.EntityState.Added)
            {
                auditableEntity.CreatedDate = now;
                auditableEntity.CreatedBy = currentUser;
            }
            else
            {
                var dbEntry = entry.GetDatabaseValues();
                auditableEntity.CreatedDate = dbEntry.GetValue<DateTime>(entry.Property(e => e.CreatedDate).Name);
                auditableEntity.CreatedBy = dbEntry.GetValue<string>(entry.Property(e => e.CreatedBy).Name);
            }
        }
    }
}

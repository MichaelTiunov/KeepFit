using System;
using System.Collections.Generic;

namespace KeepFit.Core.Models
{
    public class Menu : AuditableEntity
    {
        public Menu()
        {
            Ingestions = new List<Ingestion>();
        }
        public override int Id
        {
            get { return MenuId; }
        }

        public int MenuId { get; set; }

        public DateTime MenuDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public virtual IEnumerable<Ingestion> Ingestions { get; set; }
    }
}

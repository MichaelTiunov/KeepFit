using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepFit.Core.Models
{
    public partial class Site : AuditableEntity
    {
        public Site()
        {
            this.SubSites = new List<Site>();
        }

        public int SiteId { get; set; }

        public override int Id
        {
            get { return SiteId; }
        }

        public string Name { get; set; }

        public int IndividualRoleId { get; set; }

        public int? ParentSiteId { get; set; }

        public virtual Site ParentSite { get; set; }

        public virtual ICollection<Site> SubSites { get; set; }

        public virtual IndividualRole IndividualRole { get; set; }


    }
}

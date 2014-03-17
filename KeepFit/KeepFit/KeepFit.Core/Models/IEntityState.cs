using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepFit.Core.Models
{
    public interface IEntity
    {
        int Id { get; }

        EntityState? EntityState { get; set; }
    }
}

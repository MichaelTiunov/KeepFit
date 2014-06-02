using System.ComponentModel;

namespace KeepFit.Core.Models
{
    public enum RoleType
    {
        [Description("None")]
        Admin = 1,
        [Description("Sales Representative")]
        User = 2
    }
}

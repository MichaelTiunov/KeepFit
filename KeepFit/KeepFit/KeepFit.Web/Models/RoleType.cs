using System.ComponentModel;

namespace KeepFit.Web.Models
{
    public enum RoleType
    {
        [Description("None")]
        Admin = 0,
        [Description("Sales Representative")]
        User = 1
    }
}
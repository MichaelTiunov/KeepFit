using System.Collections.Generic;
using KeepFit.Core.Models;

namespace KeepFit.Web.Models
{
    public class ProfileModel
    {
        public IEnumerable<BodyComposition> BodyCompositions { get; set; }
    }
}
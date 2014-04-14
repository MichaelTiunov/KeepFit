using System.Collections.Generic;
using KeepFit.Core.Models;

namespace KeepFit.Web.Models.Profile
{
    public class ProfileModel
    {
        public IEnumerable<BodyComposition> BodyCompositions { get; set; }

        public ProgressPhotoModel ProgressPhoto { get; set; }
    }
}
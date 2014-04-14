using System.Collections.Generic;
using KeepFit.Core.Models;

namespace KeepFit.Web.Models.Profile
{
    public class ProgressPhotoModel
    {
        public IEnumerable<ProgressPhoto> ProgressPhotos { get; set; } 
        public string ProgressPhoto { get; set; }
    }
}
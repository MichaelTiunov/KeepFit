using System.Collections.Generic;
using KeepFit.Core.Models;

namespace KeepFit.Core.Services
{
    public interface IProgressPhotoService
    {
        IEnumerable<ProgressPhoto> GetProgressPhotos(int userId);
    }
}

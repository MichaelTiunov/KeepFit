using System.Collections.Generic;
using KeepFit.Core.Models;

namespace KeepFit.Core.Services
{
    public interface IProgressPhotoService
    {
        IEnumerable<ProgressPhoto> GetProgressPhotos(int userId);

        void SaveProgressPhoto(int userId, string base64File);
    }
}

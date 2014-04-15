using System.Collections.Generic;
using System.Linq;
using KeepFit.Core.Models;

namespace KeepFit.Core.Services
{
    public class ProgressPhotoService : IProgressPhotoService
    {
        private IKeepFitContext keepFitContext;
        public ProgressPhotoService(IKeepFitContext keepFitContext)
        {
            this.keepFitContext = keepFitContext;
        }
        public IEnumerable<ProgressPhoto> GetProgressPhotos(int userId)
        {
            return keepFitContext.ProgressPhotos.Where(x => x.UserId == userId);
        }

        public void SaveProgressPhoto(int userId, string base64File)
        {
            var progressPhoto = new ProgressPhoto
            {
                Photo = base64File,
                UserId = userId
            };
            keepFitContext.ProgressPhotos.Add(progressPhoto);
            keepFitContext.SaveChanges();
        }
    }
}

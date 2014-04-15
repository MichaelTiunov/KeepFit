using System.Collections.Generic;
using System.Linq;
using KeepFit.Core.Models;

namespace KeepFit.Core.Services
{
    public class BodyCompositionService : IBodyCompositionService
    {
        private IKeepFitContext keepFitContext;
        public BodyCompositionService(IKeepFitContext keepFitContext)
        {
            this.keepFitContext = keepFitContext;
        }

        public IEnumerable<BodyComposition> GetBodyCompositions(int userId)
        {
            return keepFitContext.BodyCompositions.Where(x => x.UserId == userId);
        }

        public void SaveBodyComposition(double height, double weight, int userId)
        {
            var bodyComposition = new BodyComposition
            {
                Height = height,
                Weight = weight,
                UserId = userId
            };
            keepFitContext.BodyCompositions.Add(bodyComposition);
            keepFitContext.SaveChanges();
        }
    }
}

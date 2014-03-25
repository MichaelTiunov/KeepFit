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

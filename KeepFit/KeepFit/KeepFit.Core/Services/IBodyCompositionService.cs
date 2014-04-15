using System.Collections.Generic;
using KeepFit.Core.Models;

namespace KeepFit.Core.Services
{
    public interface IBodyCompositionService
    {
        IEnumerable<BodyComposition> GetBodyCompositions(int userId); 
        void SaveBodyComposition(double height, double weight, int userId);
    }
}

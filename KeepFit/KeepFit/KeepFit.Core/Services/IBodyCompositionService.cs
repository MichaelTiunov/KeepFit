using System.Collections.Generic;
using KeepFit.Core.Dto;

namespace KeepFit.Core.Services
{
    public interface IBodyCompositionService
    {
        IEnumerable<BodyCompositionDto> GetBodyCompositions(int userId); 
        void SaveBodyComposition(double height, double weight, int userId);
    }
}

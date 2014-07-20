using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using KeepFit.Core.Dto;
using KeepFit.Core.Models;

namespace KeepFit.Web.Models
{
    public class CalculationModel
    {
        public CaloriesCalculationModel CaloriesCalculationModel { get; set; }

        public BodyCompositionDto BodyComposition { get; set; }

        public IEnumerable<BodyCompositionDto> BodyCompositions { get; set; }

        public IEnumerable<double> GetWeight(IEnumerable<BodyComposition> bodyCompositions)
        {
            return bodyCompositions.Select(x => x.Weight);
        }

        public IEnumerable<string> GetDate(IEnumerable<BodyComposition> bodyCompositions)
        {
            return bodyCompositions.Select(x => x.CreatedDate.ToString(CultureInfo.InvariantCulture));
        }
    }
}
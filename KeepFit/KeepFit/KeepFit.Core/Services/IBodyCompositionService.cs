namespace KeepFit.Core.Services
{
    public interface IBodyCompositionService
    {
        void SaveBodyComposition(double height, double weight, int userId);
    }
}

using KeepFit.Core.Domain.Entity;

namespace KeepFit.Core.Domain.Gym
{
    public class Gym : AuditableEntity
    {
        public int GymId { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}

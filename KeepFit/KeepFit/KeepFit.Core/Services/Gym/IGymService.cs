using System.Collections.Generic;

namespace KeepFit.Core.Services.Gym
{
    public interface IGymService
    {
        Domain.Gym.Gym AddGym(Domain.Gym.Gym gym);
        IEnumerable<Domain.Gym.Gym> GetGyms();
    }
}

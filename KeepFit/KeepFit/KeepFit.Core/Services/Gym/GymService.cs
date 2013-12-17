using System;
using KeepFit.Core.Persistence.Gym;

namespace KeepFit.Core.Services.Gym
{
    public class GymService : IGymService
    {

       private readonly IGymRepository gymRepository;


        public GymService()
            : this(new GymRepository())
        {
        }

        public GymService(IGymRepository gymRepository)
        {
            if (gymRepository == null)
                throw new ArgumentNullException("gymRepository");

            this.gymRepository = gymRepository;

        }

        public void AddGym(Domain.Gym.Gym gym)
        {
            gymRepository.AddGym(gym);
        }
    }
}

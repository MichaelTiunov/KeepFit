using System;
using System.Collections.Generic;
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

        public Domain.Gym.Gym AddGym(Domain.Gym.Gym gym)
        {
            return gymRepository.AddGym(gym);
        }

        public IEnumerable<Domain.Gym.Gym> GetGyms()
        {
            return gymRepository.GetGyms();
        }
    }
}

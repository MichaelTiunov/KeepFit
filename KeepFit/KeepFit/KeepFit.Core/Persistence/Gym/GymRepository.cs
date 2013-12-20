using System;
using System.Collections.Generic;
using KeepFit.Core.Domain.Gym.Mappers;
using KeepFit.Core.Domain.Mappers;

namespace KeepFit.Core.Persistence.Gym
{
    public class GymRepository : RepositoryBase, IGymRepository
    {
        private readonly GymDataAccess gymDAO = new GymDataAccess();
        private readonly IMapper<Domain.Gym.Gym> gymMapper;
        private readonly Func<Domain.Gym.Gym> gymFactory;

        public GymRepository()
            : this(new GymMapper(), () => new Domain.Gym.Gym())
        {
            
        }

        private GymRepository(IMapper<Domain.Gym.Gym> gymMapper, Func<Domain.Gym.Gym> gymFactory)
        {
            this.gymMapper = gymMapper;
            this.gymFactory = gymFactory;
        }

        public Domain.Gym.Gym AddGym(Domain.Gym.Gym gym)
        {
            if(gym == null)
                throw new ArgumentNullException("gym");

            return gymDAO.AddGym(gym);
        }

        public IEnumerable<Domain.Gym.Gym> GetGyms()
        {
            return Execute(() => gymDAO.GetGyms(), gymMapper, gymFactory);
        }
    }
}

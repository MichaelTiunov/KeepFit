using System;

namespace KeepFit.Core.Persistence.Gym
{
    public class GymRepository:IGymRepository
    {
        private readonly GymDataAccess gymDAO = new GymDataAccess();
       
        public void AddGym(Domain.Gym.Gym gym)
        {
            if(gym == null)
                throw new ArgumentNullException("gym");

            gymDAO.AddGym(gym);
        }
    }
}

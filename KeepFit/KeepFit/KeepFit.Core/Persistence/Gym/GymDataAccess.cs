using System.Data;
using KeepFit.Core.DataAccess;

namespace KeepFit.Core.Persistence.Gym
{
    public class GymDataAccess : DataAccessBase
    {
        internal void AddGym(Domain.Gym.Gym gym)
        {
            ExecuteNonQuery(
                KeepFitBase,
                "GymIns",
                 (db, cmd) => db.AddInParameter(cmd, "GymID", DbType.Int32, gym.GymId));
        }
    }
}

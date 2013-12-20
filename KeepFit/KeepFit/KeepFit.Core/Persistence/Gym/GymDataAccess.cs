using System.Data;
using KeepFit.Core.DataAccess;

namespace KeepFit.Core.Persistence.Gym
{
    public class GymDataAccess : DataAccessBase
    {
        internal Domain.Gym.Gym AddGym(Domain.Gym.Gym gym)
        {
            ExecuteNonQuery(
                KeepFitBase,
                "GymIns",

                (db, cmd) =>
                {
                    db.AddOutParameter(cmd, "ID", DbType.Int32, 0);
                    db.AddInParameter(cmd, "Name", DbType.String, gym.Name);
                    db.AddInParameter(cmd, "Latitude", DbType.String, gym.Latitude);
                    db.AddInParameter(cmd, "Longitude", DbType.String, gym.Longitude);
                },
                (db, cmd) =>
                {
                    gym.GymId = (int)db.GetParameterValue(cmd, "ID");
                });
            return gym;
        }

        internal IDataReader GetGyms()
        {
            return ExecuteReader(
                KeepFitBase,
                "GymsSel");
        }
    }
}

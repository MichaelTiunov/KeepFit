using System.Data;
using KeepFit.Core.Domain.Mappers;

namespace KeepFit.Core.Domain.Gym.Mappers
{
    public class GymMapper : IMapper<Gym>
    {
        public void Map(IDataReader reader, Gym res)
        {
            int index = reader.GetOrdinal("id");
            res.GymId = reader.GetInt32(index);

            index = reader.GetOrdinal("name");
            res.Name = reader.GetString(index);

            index = reader.GetOrdinal("latitude");
            res.Latitude = reader.GetFloat(index);

            index = reader.GetOrdinal("longitude");
            res.Longitude = reader.GetFloat(index);
        }
    }
}

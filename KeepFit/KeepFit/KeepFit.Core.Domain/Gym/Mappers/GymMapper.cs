using System;
using System.Data;
using KeepFit.Core.Domain.Mappers;

namespace KeepFit.Core.Domain.Gym.Mappers
{
    public class GymMapper : IMapper<Gym>
    {
        public void Map(IDataReader reader, Gym res)
        {
            var index = reader.GetOrdinal("id");
            res.GymId = reader.GetInt32(index);

            index = reader.GetOrdinal("name");
            res.Name = reader.GetString(index);

            index = reader.GetOrdinal("latitude");
            res.Latitude = Convert.ToSingle(reader.GetString(index));

            index = reader.GetOrdinal("longitude");
            res.Longitude = Convert.ToSingle(reader.GetString(index));
        }
    }
}

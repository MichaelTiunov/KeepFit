using System.Data;

namespace KeepFit.Core.Domain.Mappers
{
    public interface IMapper<in T>
    {
        void Map(IDataReader reader, T target);
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using KeepFit.Core.Domain.Mappers;

namespace KeepFit.Core.Persistence
{
    public abstract class RepositoryBase
    {
        protected T ExecuteScalar<T>(Func<object> getScalarResultDelegate)
        {
            return (T)getScalarResultDelegate();
        }

        protected T ExecuteSingle<T>(Func<IDataReader> getReader, IMapper<T> mapper, Func<T> targetFactory) where T : class
        {
            return Execute(getReader, mapper, targetFactory).FirstOrDefault();
        }

        protected T ExecuteSingle<T>(Func<IDataReader> getReader, Func<IDataReader, T> mapping)
        {
            return Execute(getReader, mapping).FirstOrDefault();
        }

        protected IEnumerable<T> Execute<T>(Func<IDataReader> getReader, IMapper<T> mapper, Func<T> targetFactory) where T : class
        {
            return Execute(getReader, mapper.Map, targetFactory);
        }

        protected IEnumerable<T> Execute<T>(Func<IDataReader> getReader, Action<IDataReader, T> mapping, Func<T> targetFactory) where T : class
        {
            if (getReader == null)
                throw new ArgumentNullException("getReaderDelegate");

            if (mapping == null)
                throw new ArgumentNullException("mapping");

            if (targetFactory == null)
                throw new ArgumentNullException("target");

            var results = new List<T>();

            using (var reader = getReader())
            {
                while (reader.Read())
                {
                    var target = targetFactory();
                    mapping(reader, target);
                    results.Add(target);
                }
            }

            return results;
        }

        protected IEnumerable<T> Execute<T>(Func<IDataReader> getReader, Action<IDataReader, T> mapping, Func<IDataReader, T> targetFactory) where T : class
        {
            if (getReader == null)
                throw new ArgumentNullException("getReaderDelegate");

            if (mapping == null)
                throw new ArgumentNullException("mapping");

            if (targetFactory == null)
                throw new ArgumentNullException("target");

            var results = new List<T>();

            using (var reader = getReader())
            {
                while (reader.Read())
                {
                    var target = targetFactory(reader);
                    mapping(reader, target);
                    results.Add(target);
                }
            }

            return results;
        }

        protected IEnumerable<T> Execute<T>(Func<IDataReader> getReader, Func<IDataReader, T> mapping)
        {
            if (getReader == null)
                throw new ArgumentNullException("getReaderDelegate");

            if (mapping == null)
                throw new ArgumentNullException("mapping");

            var results = new List<T>();

            using (var reader = getReader())
            {
                while (reader.Read())
                {
                    results.Add(mapping(reader));
                }
            }

            return results;
        }
    }
}

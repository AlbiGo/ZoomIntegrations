using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoom_Integration.Interfaces;

namespace Zoom_Integration.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public void Add(T entity)
        {

        }
        public void Update(T entity)
        {

        }
        public void Delete(T entity)
        {

        }
        public async Task SaveAsync(T entity)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zoom_Integration.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task SaveAsync(T entity);
    }
}

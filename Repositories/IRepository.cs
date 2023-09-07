using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingGalleryBs.Repositories
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(Guid id);
        public Task<T> Create(T entity);
        public Task<bool> Update(T entity);
        public Task<bool> Delete(Guid id);
    }
}
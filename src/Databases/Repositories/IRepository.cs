using Patterns.Repositories.Entities.EntityTypes;
using Patterns.Repositories.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patterns.Repositories
{
    public interface IRepository<TModel> : IDisposable where TModel : BaseEntity
    {
        IUnitOfWork UnitOfWork { get; }

        Task<TModel> GetById(Guid id);
        IEnumerable<TModel> GetAll();

        Task<int> Delete(Guid id);
        Task<int> Update(TModel obj);
        Task<int> Add(TModel obj);
    }
}

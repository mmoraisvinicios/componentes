using Dapper;
using Patterns.Repositories;
using Patterns.Repositories.Entities.EntityTypes;
using Patterns.Repositories.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Dapper
{
    public class DapperRepository<TModel> : IRepository<TModel> where TModel : BaseEntity
    {
        public virtual string Query { get; set; }

        public IUnitOfWork UnitOfWork { get; }

        public DapperRepository(IUnitOfWork uow)
        {
            UnitOfWork = uow;
        }

        #region COMANDOS

        public virtual async Task<int> Add(TModel obj) =>
            await UnitOfWork.Connection.ExecuteAsync(Query, obj, transaction: UnitOfWork.Transaction);

        public virtual async Task<int> Update(TModel obj) =>
           await UnitOfWork.Connection.ExecuteAsync(Query, obj, transaction: UnitOfWork.Transaction);

        public virtual async Task<int> Delete(Guid id) =>
            await UnitOfWork.Connection.ExecuteAsync(Query, new { id }, transaction: UnitOfWork.Transaction);

        #endregion

        #region CONSULTAS

        public virtual IEnumerable<TModel> GetAll() =>
              UnitOfWork.Connection.Query<TModel>(Query, transaction: UnitOfWork.Transaction);

        public virtual Task<TModel> GetById(Guid id) =>
            UnitOfWork.Connection.QueryFirstOrDefaultAsync<TModel>(Query, new { Id = id }, transaction: UnitOfWork.Transaction);

        public virtual Task<TModel> GetById(int id) =>
            UnitOfWork.Connection.QueryFirstOrDefaultAsync<TModel>(Query, new { Id = id }, transaction: UnitOfWork.Transaction);

        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            UnitOfWork.Connection.Close();
            UnitOfWork.Dispose();
        }
    }
}

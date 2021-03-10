using Microsoft.Extensions.Configuration;
using Patterns.Repositories.Configuration.Interfaces;
using Patterns.Repositories.UnitOfWork.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Patterns.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection = null;
        private IDbTransaction _transaction = null;

        string ConnectionString;

        public UnitOfWork(IConfiguration configuration, IDataBaseProperties dataBaseProperties)
        {
            ConnectionString = configuration.GetConnectionString(dataBaseProperties.ConnectionStringName);
        }

        IDbConnection IUnitOfWork.Connection
        {
            get { return GetConnection(); }
        }

        IDbTransaction IUnitOfWork.Transaction
        {
            get { return _transaction; }
        }

        private IDbConnection GetConnection()
        {
            if (_connection == null)
                _connection = new SqlConnection(ConnectionString);

            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            return _connection;
        }

        public void Begin()
        {
            _transaction = GetConnection().BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
            DisposeTransaction();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            DisposeTransaction();
        }

        public void DisposeTransaction()
        {
            if (_transaction != null)
                _transaction.Dispose();
            _transaction = null;
        }

        public void Dispose()
        {
            DisposeTransaction();

            if (_connection != null)
                _connection.Dispose();
            _connection = null;
        }
    }
}

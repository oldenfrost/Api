using Api.Infrastructure.Interfaces;
using Npgsql;
using ProcWizard;
using ProcWizard.Models;
using System.Data;

namespace Api.Infrastructure.DataAccess
{
    public class PostgreSQLDataAccess : IDataAcces
    {
        private readonly string _connString;
        public PostgreSQLDataAccess(IConfiguration cfg)
        {
            _connString = cfg.GetConnectionString("PostgreSql")!;
        }
        public void Execute<T>(string CommnadText, object? parameters = null)
        {
            throw new NotImplementedException();
        }

        public async Task ExecuteAsync<T>(string CommnadText, object? parameters = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> MultiQueryListAsync<T>(List<MultiCommand> commands, object? parameters = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> MultiQuerySingleAsync<T>(List<MultiCommand> commands, object? parameters = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> SelectListAsync<T>(string CommnadText, object? parameters = null)
        {
            throw new NotImplementedException();
        }

        public async Task<T> SelectSingleAsync<T>(string CommnadText, object? parameters = null)
        {
            //using ( var cnn =new NpgsqlConnection(_connString))
            //{
            //     return await cnn.SelectSingleAsync<T>(CommnadText, parameters);  se le puede decir el tipo de commando pero no es necesario puede detectar si es un text o un store procedure
            //}
            throw new NotImplementedException();
        }
    }
}

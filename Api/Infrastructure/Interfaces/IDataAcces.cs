using ProcWizard.Models;
using System.Data;

namespace Api.Infrastructure.Interfaces
{
    public interface IDataAcces
    {
        void Execute<T>(string CommnadText, object? parameters = null);
        Task ExecuteAsync<T>(string CommnadText, object? parameters = null);

        Task<IEnumerable<T>> MultiQueryListAsync<T>(List<MultiCommand> commands, object? parameters = null);
        Task<IEnumerable<T>> MultiQuerySingleAsync<T>(List<MultiCommand> commands, object? parameters = null);

        Task<IEnumerable<T>> SelectListAsync<T>(string CommnadText, object? parameters = null);
        Task<T> SelectSingleAsync<T>(string CommnadText, object? parameters = null);


    }
}

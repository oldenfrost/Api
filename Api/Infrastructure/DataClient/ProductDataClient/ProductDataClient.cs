using Api.Infrastructure.Interfaces;
using Api.Domain.Entities;
using ProcWizard.Models;
using ProcWizard.Enumeration;
using System.Data;

namespace Api.Infrastructure.DataClient.ProductDataClient
{
    public class ProductDataClient : IProductDataClient
    {
        private readonly IDataAcces _dataAcces;
        public ProductDataClient(IDataAcces dataAcces)
        {
            _dataAcces = dataAcces;
        }
        public async Task<Product> GetProductAsync(Product product)

        {
            //creacion dinamica de parametros para cualquier tipo de gesto es solo necesario para parametro en especifico que sea necesario
            // en dado caso solo se pasa como un atributo al new { id = 1 } pero este es un ejemplo
            // multiquery mas que todo para postgre en sql oracle o mysql se puede llamar al sp
            //DynamicParamBuilder dynamicParam = new DynamicParamBuilder();
            //dynamicParam.Add(name: "Ejemplo_Id", value: 1, dbType: NpgSqlType.Integer, direction: ParameterDirection.Input);
            //List<MultiCommand> commands = new List<MultiCommand>();
            //commands.Add(new MultiCommand("CALL sp_get_all_postgres('mycursor');", false));
            //commands.Add(new MultiCommand("FETCH ALL FROM mycursor;", true));

            return product;

            //return await  _dataAcces.SelectSingleAsync<Product>("sp", new { id = 1 }); aca se llamaria el nugget para ejecutar la conexion con base de datos


        }
    }
}

using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EmployeeManagement.Repository
{
    public class BaseRepository
    {
        protected readonly string conectionString;

        public BaseRepository(IOptions<DbConfiguration> options)
        {
            conectionString = options.Value.ConnectionString;
        }

        public virtual void ExecuteMySql(string query, object parms, int commandTimeout = 30)
        {
            using (var connection = new MySqlConnection(conectionString))
            {
                connection.Query(query, parms, commandType: CommandType.Text, commandTimeout: commandTimeout);
            }
        }

        public virtual T ExecuteMySqlReturnFirst<T>(string query, object parms, int commandTimeout = 30)
        {
            using (var connection = new MySqlConnection(conectionString))
            {
                return connection.Query<T>(query, parms, commandType: CommandType.Text, commandTimeout: commandTimeout)
                    .FirstOrDefault();
            }
        }

        public virtual List<T> ExecuteMySqlReturnList<T>(string query, object parms, int commandTimeout = 30)
        {
            using (var connection = new MySqlConnection(conectionString))
            {
                return connection.Query<T>(query, parms, commandType: CommandType.Text, commandTimeout: commandTimeout)
                    .ToList();
            }
        }
    }
}

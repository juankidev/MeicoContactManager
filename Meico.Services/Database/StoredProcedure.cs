using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Meico.Services.Database
{
    public class StoredProcedure
    {
        private readonly string _connectionString;
        private readonly string _procedureName;
        private readonly List<SqlParameter> _parameters;

        public StoredProcedure(string procedureName)
        {
            _connectionString = "Data Source=localhost;Initial Catalog=MeicoAssesment;Persist Security Info=True;User ID=MeicoMaster;Password=meico1234#; TrustServerCertificate=true;";

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ApplicationException("DefaultConnection is not defined in appsettings.json");
            }

            _procedureName = procedureName;
            _parameters = new List<SqlParameter>();
        }

        public void AddParameter(string parameterName, object value)
        {
            _parameters.Add(new SqlParameter(parameterName, value ?? DBNull.Value));
        }

        public IEnumerable<T> ExecuteStoredProcedure<T>()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = _procedureName;
                    command.Parameters.AddRange(_parameters.ToArray());

                    var reader = command.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    return ConvertDataTable<T>(dataTable);
                }
            }
        }

        private IEnumerable<T> ConvertDataTable<T>(DataTable dataTable)
        {
            var properties = typeof(T).GetProperties();
            return dataTable.AsEnumerable().Select(row =>
            {
                var obj = Activator.CreateInstance<T>();
                foreach (var prop in properties)
                {
                    try
                    {
                        if (dataTable.Columns.Contains(prop.Name) && row[prop.Name] != DBNull.Value)
                        {
                            prop.SetValue(obj, Convert.ChangeType(row[prop.Name], prop.PropertyType));
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle conversion errors
                    }
                }
                return obj;
            });
        }
    }
}

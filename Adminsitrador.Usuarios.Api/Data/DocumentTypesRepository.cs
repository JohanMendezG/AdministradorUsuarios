using Adminsitrador.Usuarios.Api.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Adminsitrador.Usuarios.Api.Data
{
    public class DocumentTypesRepository
    {
        private readonly string _configuration;

        public DocumentTypesRepository(IConfiguration configuration)
        {
            _configuration = configuration.GetConnectionString("DefaultConection");
        }

        public async Task<List<DocumentType>> Get()
        {
            using (var sql = new SqlConnection(_configuration))
            {
                using (var cmd = new SqlCommand("SELECT * FROM DOCUMENTTYPES", sql))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    var response = new List<DocumentType>();
                    await sql.OpenAsync().ConfigureAwait(false);
                    using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        while (await reader.ReadAsync().ConfigureAwait(false))
                        {
                            response.Add(MapToUser(reader));
                        }
                    }

                    return response;
                }
            }
        }

        private DocumentType MapToUser(SqlDataReader reader)
        {
            return new DocumentType()
            {
                Id = (int)reader["id"],
                DocumenType = reader["documentType"].ToString(),
            };
        }
    }
}

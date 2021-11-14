using Adminsitrador.Usuarios.Api.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Adminsitrador.Usuarios.Api.Data
{
    public class ProfilesRepository
    {
        private readonly string _configuration;

        public ProfilesRepository(IConfiguration configuration)
        {
            _configuration = configuration.GetConnectionString("DefaultConection");
        }

        public async Task<List<Profile>> Get()
        {
            using (var sql = new SqlConnection(_configuration))
            {
                using (var cmd = new SqlCommand("SELECT * FROM PROFILES", sql))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    var response = new List<Profile>();
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

        private Profile MapToUser(SqlDataReader reader)
        {
            return new Profile()
            {
                Id = (int)reader["id"],
                _Profile = reader["profile"].ToString(),
            };
        }
    }
}

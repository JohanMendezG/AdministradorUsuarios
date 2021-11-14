using Adminsitrador.Usuarios.Api.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Adminsitrador.Usuarios.Api.Data
{
    public class UsersRepository
    {
        private readonly string _configuration;

        public UsersRepository(IConfiguration configuration)
        {
            _configuration = configuration.GetConnectionString("DefaultConection");
        }

        public async Task<List<User>> Get()
        {
            using (var sql = new SqlConnection(_configuration))
            {
                using (var cmd = new SqlCommand("SP_USERS_GET", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", DBNull.Value));
                    var response = new List<User>();
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

        public async Task<User> GetById(long id)
        {
            using (var sql = new SqlConnection(_configuration))
            {
                using (var cmd = new SqlCommand("SP_USERS_GET", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    User response = null;
                    await sql.OpenAsync().ConfigureAwait(false);
                    using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        while (await reader.ReadAsync().ConfigureAwait(false))
                        {
                            response = MapToUser(reader);
                        }
                    }

                    return response;
                }
            }
        }

        public async Task<long> Insert(User user)
        {
            using (var sql = new SqlConnection(_configuration))
            {
                using (var cmd = new SqlCommand("SP_USERS_INSERT", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@documentType_id", user.DocumentType_id));
                    cmd.Parameters.Add(new SqlParameter("@documentNumber", user.DocumentNumber));
                    cmd.Parameters.Add(new SqlParameter("@name", user.Name));
                    cmd.Parameters.Add(new SqlParameter("@surname", user.Surname));
                    cmd.Parameters.Add(new SqlParameter("@login", user.Login));
                    cmd.Parameters.Add(new SqlParameter("@password", user.Password));
                    cmd.Parameters.Add(new SqlParameter("@email", user.Email));
                    cmd.Parameters.Add(new SqlParameter("@createBy", user.CreateBy));
                    cmd.Parameters.Add(new SqlParameter("@dateCreate", user.DateCreate));
                    if (user.ModifyBy == null || user.DateModify == null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@modifyBy", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@dateModify", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@modifyBy", user.ModifyBy));
                        cmd.Parameters.Add(new SqlParameter("@dateModify", user.DateModify));
                    }
                    cmd.Parameters.Add(new SqlParameter("@active", user.Active));
                    cmd.Parameters.Add(new SqlParameter("@profile_id", user.Profile_Id));
                    cmd.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.BigInt)).Direction = System.Data.ParameterDirection.Output;
                    await sql.OpenAsync().ConfigureAwait(false);
                    var row = await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                    long response = Convert.ToInt64(cmd.Parameters["@id"].Value);

                    return response;
                }
            }
        }

        public async Task<bool> Update(User user)
        {
            using (var sql = new SqlConnection(_configuration))
            {
                using (var cmd = new SqlCommand("SP_USERS_UPDATE", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", user.Id));
                    cmd.Parameters.Add(new SqlParameter("@documentType_id", user.DocumentType_id));
                    cmd.Parameters.Add(new SqlParameter("@documentNumber", user.DocumentNumber));
                    cmd.Parameters.Add(new SqlParameter("@name", user.Name));
                    cmd.Parameters.Add(new SqlParameter("@surname", user.Surname));
                    cmd.Parameters.Add(new SqlParameter("@login", user.Login));
                    cmd.Parameters.Add(new SqlParameter("@password", user.Password));
                    cmd.Parameters.Add(new SqlParameter("@email", user.Email));
                    if (user.ModifyBy == null || user.DateModify == null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@modifyBy", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@dateModify", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@modifyBy", user.ModifyBy));
                        cmd.Parameters.Add(new SqlParameter("@dateModify", user.DateModify));
                    }
                    cmd.Parameters.Add(new SqlParameter("@active", user.Active));
                    cmd.Parameters.Add(new SqlParameter("@profile_id", user.Profile_Id));
                    cmd.Parameters.Add(new SqlParameter("@validation", System.Data.SqlDbType.Bit)).Direction = System.Data.ParameterDirection.Output;
                    await sql.OpenAsync().ConfigureAwait(false);
                    var row = await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                    bool response = Convert.ToBoolean(cmd.Parameters["@validation"].Value);

                    return response;
                }
            }
        }

        private User MapToUser(SqlDataReader reader)
        {
            return new User()
            {
                Id = (long)reader["id"],
                DocumentType_id = (int)reader["documentType_id"],
                DocumentNumber = (long)reader["documentNumber"],
                Name = reader["name"].ToString(),
                Surname = reader["surname"].ToString(),
                Login = reader["login"].ToString(),
                Password = reader["password"].ToString(),
                Email = reader["email"].ToString(),
                CreateBy = (long)reader["createBy"],
                DateCreate = (DateTime)reader["dateCreate"],
                ModifyBy = reader["modifyBy"] == DBNull.Value ? null : (long?)reader["modifyBy"],
                DateModify = reader["dateModify"] == DBNull.Value ? null : (DateTime?)reader["dateModify"],
                Active = (bool)reader["active"],
                Profile_Id = (int)reader["profile_id"]
            };
        }
    }
}

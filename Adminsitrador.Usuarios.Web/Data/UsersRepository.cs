using Adminsitrador.Usuarios.Web.Models;
using Adminsitrador.Usuarios.Web.Utilities;
using Adminsitrador.Usuarios.Web.Utilities.UrlApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;

namespace Adminsitrador.Usuarios.Web.Data
{
    public class UsersRepository
    {
        private readonly UrlUsers urlUsers;

        public UsersRepository(UrlUsers urlUsers)
        {
            this.urlUsers = urlUsers;
        }

        public List<UserRequest> GetUsers()
        {
            try
            {
                var url = urlUsers.GetUrlUsers();
                var jsonResponse = JsonResponse.GetJson(url);
                var listUsers = JsonSerializer.Deserialize<List<UserRequest>>(jsonResponse);

                return listUsers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UserRequest GetUsers(long id)
        {
            try
            {
                var url = urlUsers.GetUrlUsers(id);
                var jsonResponse = JsonResponse.GetJson(url);
                var users = JsonSerializer.Deserialize<UserRequest>(jsonResponse);

                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long PostUsersInsert(UserRequest user)
        {
            try
            {
                var jsonBody = JsonSerializer.Serialize<UserRequest>(user);
                HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                var url = urlUsers.InsertUrlUsers();
                var jsonResponse = JsonResponse.PostJson(url, content);
                var idResponse = JsonSerializer.Deserialize<long>(jsonResponse);

                return idResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool PostUsersUpdate(UserRequest user)
        {
            try
            {
                var jsonBody = JsonSerializer.Serialize<UserRequest>(user);
                HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                var url = urlUsers.UpdateUrlUsers();
                var jsonResponse = JsonResponse.PostJson(url, content);
                var response = JsonSerializer.Deserialize<bool>(jsonResponse);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

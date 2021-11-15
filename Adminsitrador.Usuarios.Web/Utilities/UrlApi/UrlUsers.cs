using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adminsitrador.Usuarios.Web.Utilities.UrlApi
{
    public class UrlUsers
    {
        public string GetUrlUsers()
        {
            return $"{GetUrlAdminUsers()}/Users";
        }

        public string GetUrlUsers(long id)
        {
            return $"{GetUrlAdminUsers()}/Users/{id}";
        }

        public string InsertUrlUsers()
        {
            return $"{GetUrlAdminUsers()}/Users/Insert";
        }

        public string UpdateUrlUsers()
        {
            return $"{GetUrlAdminUsers()}/Users/Update";
        }

        private string GetUrlAdminUsers()
        {
            return Environment.GetEnvironmentVariable("urlApiAdminUsers");
        }
    }
}

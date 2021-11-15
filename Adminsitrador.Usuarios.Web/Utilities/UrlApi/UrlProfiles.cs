using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adminsitrador.Usuarios.Web.Utilities.UrlApi
{
    public class UrlProfiles
    {
        public string GetUrlProfiles()
        {
            return $"{GetUrlAdminUsers()}/Profiles";
        }

        private string GetUrlAdminUsers()
        {
            return Environment.GetEnvironmentVariable("urlApiAdminUsers");
        }
    }
}

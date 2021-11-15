using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adminsitrador.Usuarios.Web.Utilities.UrlApi
{
    public class UrlDocumentTypes
    {
        public string GetUrlDocumentTypes()
        {
            return $"{GetUrlAdminUsers()}/DocumentTypes";
        }

        private string GetUrlAdminUsers()
        {
            return Environment.GetEnvironmentVariable("urlApiAdminUsers");
        }
    }
}

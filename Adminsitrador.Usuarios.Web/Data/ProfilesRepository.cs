using Adminsitrador.Usuarios.Web.Models;
using Adminsitrador.Usuarios.Web.Utilities;
using Adminsitrador.Usuarios.Web.Utilities.UrlApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Adminsitrador.Usuarios.Web.Data
{
    public class ProfilesRepository
    {
        private readonly UrlProfiles urlProfiles;

        public ProfilesRepository(UrlProfiles urlProfiles)
        {
            this.urlProfiles = urlProfiles;
        }

        public List<Profile> GetProfiles()
        {
            try
            {
                var url = urlProfiles.GetUrlProfiles();
                var jsonResponse = JsonResponse.GetJson(url);
                var listProfiles = JsonSerializer.Deserialize<List<Profile>>(jsonResponse);

                return listProfiles;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

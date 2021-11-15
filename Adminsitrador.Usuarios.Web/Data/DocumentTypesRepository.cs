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
    public class DocumentTypesRepository
    {
        private readonly UrlDocumentTypes urlDocumentTypes;

        public DocumentTypesRepository(UrlDocumentTypes urlDocumentTypes)
        {
            this.urlDocumentTypes = urlDocumentTypes;
        }

        public List<DocumentType> GetDocumentTypes()
        {
            try
            {
                var url = urlDocumentTypes.GetUrlDocumentTypes();
                var jsonResponse = JsonResponse.GetJson(url);
                var listDocumentTypes = JsonSerializer.Deserialize<List<DocumentType>>(jsonResponse);

                return listDocumentTypes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

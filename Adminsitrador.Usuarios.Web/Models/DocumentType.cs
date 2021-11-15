using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Adminsitrador.Usuarios.Web.Models
{
    public class DocumentType
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("documenType")]
        public string _DocumentType { get; set; }
    }
}

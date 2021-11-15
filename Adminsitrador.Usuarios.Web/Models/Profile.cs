using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Adminsitrador.Usuarios.Web.Models
{
    public class Profile
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("_Profile")]
        public string _Profile { get; set; }
    }
}

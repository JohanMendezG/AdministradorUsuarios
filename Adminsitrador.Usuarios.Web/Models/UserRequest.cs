using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Adminsitrador.Usuarios.Web.Models
{
    public class UserRequest
    {
        [Required]
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [Required(ErrorMessage = "El tipo de documento es obligatorio")]
        [RegularExpression("^[0-9]{1,}$")]
        [JsonPropertyName("documentType_id")]
        public int DocumentType_id { get; set; }

        [Required(ErrorMessage = "El numero de documento es obligatorio")]
        [RegularExpression("^[0-9]{5,12}$", ErrorMessage = "Se debe ingresar entre 5 y 12 caracteres")]
        [JsonPropertyName("documentNumber")]
        public long DocumentNumber { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression("^[a-zA-Z ]{1,30}$", ErrorMessage = "Se debe ingresar maximo 30 caracteres alfabeticos")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [RegularExpression("^[a-zA-Z ]{1,30}$", ErrorMessage = "Se debe ingresar maximo 30 caracteres alfabeticos")]
        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        [RegularExpression("^[a-zA-Z0-9]{1,20}$", ErrorMessage = "Se debe ingresar maximo 20 caracteres alfanumericos")]
        [JsonPropertyName("login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "La clave es obligatoria")]
        [RegularExpression("^[a-zA-Z0-9]{1,20}$", ErrorMessage = "Se debe ingresar maximo 20 caracteres alfanumericos")]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email no es valido")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Es obligatorio asignar quien crea")]
        [RegularExpression("^[0-9]{1,}$")]
        [JsonPropertyName("createBy")]
        public long CreateBy { get; set; }

        [Required(ErrorMessage = "la fecha de creacion es obligatoria")]
        [DataType(DataType.Date)]
        [JsonPropertyName("dateCreate")]
        public DateTime DateCreate { get; set; }

        [JsonPropertyName("modifyBy")]
        public long? ModifyBy { get; set; }

        [DataType(DataType.Date)]
        [JsonPropertyName("dateModify")]
        public DateTime? DateModify { get; set; }

        [Required(ErrorMessage = "Es obligatorio asignar su estado")]
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "El perfil es obligatorio")]
        [RegularExpression("^[0-9]{1,}$")]
        [JsonPropertyName("profile_Id")]
        public int Profile_Id { get; set; }
    }
}

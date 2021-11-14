using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Adminsitrador.Usuarios.Api.Models
{
    [Serializable]
    public class User
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required(ErrorMessage = "El tipo de documento es obligatorio")]
        [RegularExpression("^[0-9]{1,}$")]
        public int DocumentType_id { get; set; }

        [Required(ErrorMessage = "El numero de documento es obligatorio")]
        [RegularExpression("^[0-9]{5,12}$", ErrorMessage = "Se debe ingresar entre 5 y 12 caracteres")]
        public long DocumentNumber { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression("^[a-zA-Z ]{1,30}$", ErrorMessage = "Se debe ingresar maximo 30 caracteres alfabeticos")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [RegularExpression("^[a-zA-Z ]{1,30}$", ErrorMessage = "Se debe ingresar maximo 30 caracteres alfabeticos")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        [RegularExpression("^[a-zA-Z0-9]{1,20}$", ErrorMessage = "Se debe ingresar maximo 20 caracteres alfanumericos")]
        public string Login { get; set; }

        [Required(ErrorMessage = "La clave es obligatoria")]
        [RegularExpression("^[a-zA-Z0-9]{1,20}$", ErrorMessage = "Se debe ingresar maximo 20 caracteres alfanumericos")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email no es valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Es obligatorio asignar quien crea")]
        [RegularExpression("^[0-9]{1,}$")]
        public long CreateBy { get; set; }

        [Required(ErrorMessage = "la fecha de creacion es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime DateCreate { get; set; }

        public long? ModifyBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateModify { get; set; }

        [Required(ErrorMessage = "Es obligatorio asignar su estado")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "El perfil es obligatorio")]
        [RegularExpression("^[0-9]{1,}$")]
        public int Profile_Id { get; set; }
    }
}

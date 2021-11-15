using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Adminsitrador.Usuarios.Web.Models
{
    public class UserResponse
    {
        public string Mod { get; set; }

        [Display(Name = "ID")]
        public long Id { get; set; }

        [Display(Name = "Tipo.Doc")]
        public string DocumentType { get; set; }

        [Display(Name = "Nro.Doc")]
        public long DocumentNumber { get; set; }

        [Display(Name = "Nombres")]
        public string Names { get; set; }
        
        [Display(Name = "Apellido")]
        public string Surname { get; set; }

        public string Login { get; set; }

        [Display(Name = "Perfil")]
        public string Profile { get; set; }

        [Display(Name = "Fecha creación")]
        public string DateCreate { get; set; }

        [Display(Name = "Activo")]
        public string Active { get; set; }
    }
}

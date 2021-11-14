using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Adminsitrador.Usuarios.Api.Models
{
    //[Serializable]
    public class User
    {
        public long Id { get; set; }
        public int DocumentType_id { get; set; }
        public long DocumentNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public long CreateBy { get; set; }
        public DateTime DateCreate { get; set; }
        public long? ModifyBy { get; set; }
        public DateTime? DateModify { get; set; }
        public bool Active { get; set; }
        public int Profile_Id { get; set; }
    }
}

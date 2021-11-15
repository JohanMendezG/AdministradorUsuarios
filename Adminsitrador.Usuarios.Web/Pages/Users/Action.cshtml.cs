using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adminsitrador.Usuarios.Web.Data;
using Adminsitrador.Usuarios.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Adminsitrador.Usuarios.Web.Pages.Users
{
    public class ActionModel : PageModel
    {
        private readonly UsersRepository usersRepository;
        private readonly ProfilesRepository profilesRepository;
        private readonly DocumentTypesRepository documentTypesRepository;

        [BindProperty]
        public UserRequest User { get; set; }
        public List<Profile> Profiles { get; set; }
        public List<DocumentType> DocumentTypes { get; set; }
        public long? Id { get; set; }
        public string Message { get; set; }

        public ActionModel(UsersRepository usersRepository, ProfilesRepository profilesRepository, DocumentTypesRepository documentTypesRepository)
        {
            this.usersRepository = usersRepository;
            this.profilesRepository = profilesRepository;
            this.documentTypesRepository = documentTypesRepository;
        }

        public void OnGet(long? id)
        {
            Id = id;
            Init(id);
        }

        public void OnPostNew()
        {
            try
            {
                var userRequest = new UserRequest()
                {
                    Active = User.Active,
                    CreateBy = 1111111111,
                    DateCreate = DateTime.Now,
                    DateModify = null,
                    DocumentNumber = User.DocumentNumber,
                    DocumentType_id = User.DocumentType_id,
                    Email = $"{User.Name}@{User.Surname}",
                    Login = User.Login,
                    ModifyBy = null,
                    Name = User.Name,
                    Password = User.Password,
                    Profile_Id = User.Profile_Id,
                    Surname = User.Surname
                };
                var idResponse = usersRepository.PostUsersInsert(userRequest);
                if (idResponse == 0)
                    Message = $"Error al insertar el registro, valide los campos";
                else
                    Message = $"Se inserto correctamente el id {idResponse}";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            Init(null);
        }

        public void OnPostUpdate()
        {
            try
            {
                var userRequest = new UserRequest()
                {
                    Id = User.Id,
                    Active = User.Active,
                    CreateBy = User.CreateBy,
                    DateCreate = User.DateCreate,
                    DateModify = DateTime.Now,
                    DocumentNumber = User.DocumentNumber,
                    DocumentType_id = User.DocumentType_id,
                    Email = User.Email,
                    Login = User.Login,
                    ModifyBy = 1111111111,
                    Name = User.Name,
                    Password = User.Password,
                    Profile_Id = User.Profile_Id,
                    Surname = User.Surname
                };
                var response = usersRepository.PostUsersUpdate(userRequest);
                if (response)
                    Message = $"El registro se actualizo correctamente";
                else
                    Message = $"Error al actualizar el registro";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            Init(User.Id);
        }

        private void Init(long? id)
        {
            Profiles = profilesRepository.GetProfiles();
            DocumentTypes = documentTypesRepository.GetDocumentTypes();

            if (id != null)
            {
                User = usersRepository.GetUsers(id.Value);
            }
        }
    }
}

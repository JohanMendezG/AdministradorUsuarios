using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adminsitrador.Usuarios.Web.Data;
using Adminsitrador.Usuarios.Web.Models;
using Adminsitrador.Usuarios.Web.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Adminsitrador.Usuarios.Web.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly UsersRepository usersRepository;
        private readonly ProfilesRepository profilesRepository;
        private readonly DocumentTypesRepository documentTypesRepository;
        public List<UserResponse> Users { get; set; }
        public List<Profile> Profiles { get; set; }
        public List<DocumentType> DocumentTypes { get; set; }

        public IndexModel(UsersRepository usersRepository, ProfilesRepository profilesRepository, DocumentTypesRepository documentTypesRepository)
        {
            this.usersRepository = usersRepository;
            this.profilesRepository = profilesRepository;
            this.documentTypesRepository = documentTypesRepository;
        }

        public void OnGet()
        {
            try
            {
                var userRequests = usersRepository.GetUsers();
                Profiles = profilesRepository.GetProfiles();
                DocumentTypes = documentTypesRepository.GetDocumentTypes();

                Users = MapUser.MapUserResponse(userRequests, Profiles, DocumentTypes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

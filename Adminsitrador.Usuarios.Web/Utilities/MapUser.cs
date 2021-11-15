using Adminsitrador.Usuarios.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adminsitrador.Usuarios.Web.Utilities
{
    public class MapUser
    {
        public static List<UserResponse> MapUserResponse(List<UserRequest> userRequests, List<Profile> profiles, List<DocumentType> documentTypes)
        {
            var listUserResponse = new List<UserResponse>();
            foreach (var item in userRequests)
            {
                listUserResponse.Add(new UserResponse()
                {
                    Mod = $"/Users/Action/{item.Id}",
                    Id = item.Id,
                    DocumentType = documentTypes.Where(x => x.Id == item.DocumentType_id).FirstOrDefault()._DocumentType,
                    DocumentNumber = item.DocumentNumber,
                    Names = item.Name,
                    Surname = item.Surname,
                    Login = item.Login,
                    Profile = profiles.Where(x => x.Id == item.Profile_Id).FirstOrDefault()._Profile,
                    DateCreate = item.DateCreate.ToString("dd-MM-yyyy"),
                    Active = item.Active ? "x" : string.Empty
                });
            }

            return listUserResponse;
        }
    }
}

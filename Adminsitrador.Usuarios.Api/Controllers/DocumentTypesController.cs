using Adminsitrador.Usuarios.Api.Data;
using Adminsitrador.Usuarios.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adminsitrador.Usuarios.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypesController : Controller
    {
        private readonly DocumentTypesRepository _repository;

        public DocumentTypesController(DocumentTypesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<DocumentType>>> Get()
        {
            try
            {
                return await _repository.Get().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

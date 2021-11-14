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
    public class UsersController : Controller
    {
        private readonly UsersRepository _repository;

        public UsersController(UsersRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
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

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(long id)
        {
            try
            {
                var response = await _repository.GetById(id).ConfigureAwait(false);
                if (response == null)
                    return NotFound();
                return response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("{action}")]
        public async Task<ActionResult<long>> Insert([FromBody] User user)
        {
            try
            {
                return await _repository.Insert(user).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("{action}")]
        public async Task<ActionResult<bool>> Update([FromBody] User user)
        {
            try
            {
                return await _repository.Update(user).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

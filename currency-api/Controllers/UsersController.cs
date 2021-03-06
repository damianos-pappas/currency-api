using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using currencyApi.Models;
using currencyApi.BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace currencyApi.Controllers
{
    [Authorize(Roles = "admin-users")]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        IUserService _srv;
        IUnitOfWork _unitOfWork;
        public UsersController(IUserService srv, IUnitOfWork unitOfWork)
        {
            this._srv = srv;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public PagedItems<UserDTO> Get([FromQuery]int pageNumber = 0, int pageSize = 0, string sortTerm = null, bool sortDesc = false, string searchTerm = null)
        {
            var users = _srv.Get(pageNumber, pageSize, sortTerm, sortDesc, searchTerm);

            return new PagedItems<UserDTO>
            {
                Items = _srv.MapToDTO(users.Items),
                PageNumber = users.PageNumber,
                TotalPages = users.TotalPages
            };
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDTO> GetById(long id)
        {
            var user = _srv.Get(id);

            if (user == null)
                return NotFound("User not found");
            else
                return Ok(_srv.MapToDTO(user));
        }

        [HttpGet("roles")]
        public IEnumerable<string> GetUserRoles()
        {
            return _srv.GetUserRoles();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<UserDTO> Add([FromBody] UserDTO userDTO)
        {
            var addedUser = _srv.Add(userDTO);

            _unitOfWork.Commit();

            var addedUserWithRoles = _srv.Get(addedUser.Id);

            return CreatedAtAction(nameof(GetById), new { id = addedUserWithRoles.Id }, _srv.MapToDTO(addedUserWithRoles));
        }

        [HttpPut]
        public UserDTO Update([FromBody] UserDTO userDTO)
        {
            var updatedUser = _srv.UpdateWithoutPassword(userDTO);

            _unitOfWork.Commit();

            var updatedUserWithRoles = _srv.Get(updatedUser.Id);

            return _srv.MapToDTO(updatedUserWithRoles);
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _srv.Delete(id);

            _unitOfWork.Commit();

        }
    }
}

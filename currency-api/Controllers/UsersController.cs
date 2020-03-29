using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using currencyApi.Models;
using currencyApi.BusinessLogic.Services;

namespace currencyApi.Controllers
{
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
        public IEnumerable<UserDTO> Get([FromQuery]int pageNumber =0, int pageSize =0, string sortTerm = null, bool sortDesc = false, string searchTerm = null)
        {
            var users = _srv.Get( pageNumber,  pageSize,  sortTerm, sortDesc, searchTerm);
            
            return _srv.MapToDTO(users);
        }

        [HttpGet("{id}")]
        public UserDTO Get(long id)
        {
            var user = _srv.Get(id);

            return  _srv.MapToDTO(user);
        }

        [HttpPost]
        public UserDTO Add([FromBody] UserDTO userDTO)
        {
            var addedUser = _srv.Add(userDTO);

            _unitOfWork.Commit();

            var addedUserWithRoles = _srv.Get(addedUser.Id);

            return _srv.MapToDTO(addedUserWithRoles);
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
        public void Delete( long id)
        {
            _srv.Delete(id);

            _unitOfWork.Commit();

        }
    }
}
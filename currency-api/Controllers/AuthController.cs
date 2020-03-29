using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using currencyApi.BusinessLogic.Services;
using currencyApi.Data;
using currencyApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace currencyApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        IAuthorisationService _srv;
        IUnitOfWork _unitOfWork;
        public AuthController(IAuthorisationService srv, IUnitOfWork unitOfWork)
        {
            this._srv = srv;
            this._unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        [HttpPost, Route("login")]
        public ActionResult<UserLoginDTO> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            var response = _srv.Login(userLoginDTO);
            if (response == null)
                return Unauthorized("Wrong username or password");
            else 
            return Ok(response);
        }

        [HttpPost, Route("reset-password")]
        public void ResetPassword([FromBody] UserLoginDTO userLoginDTO)
        {
            _srv.UpdatePassword(userLoginDTO);
            _unitOfWork.Commit();
        }
    }
}

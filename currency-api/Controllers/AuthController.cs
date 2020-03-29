using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using currencyApi.BusinessLogic.Services;
using currencyApi.Data;
using currencyApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace currencyApi.Controllers
{
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

        [HttpPost, Route("login")]
        public UserLoginDTO Login([FromBody] UserLoginDTO userLoginDTO)
        {
            return _srv.Login(userLoginDTO);
        }

        [HttpPost,Route("reset-password")]
        public void ResetPassword([FromBody] UserLoginDTO userLoginDTO)
        {
            _srv.UpdatePassword(userLoginDTO);
        }
    }
}

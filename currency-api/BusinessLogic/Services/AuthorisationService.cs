
using System;
using System.Linq;
using AutoMapper;
using currencyApi.BusinessLogic.Helpers;
using currencyApi.Data;
using currencyApi.Helpers;
using currencyApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace currencyApi.BusinessLogic.Services
{
    public class AuthorisationService : IAuthorisationService
    {

        IUsersRepository _usersRepo;
        IMapper _mapper;

        AppSettings _appSettings;
        double hoursForTokenToExpire = 8;
        public AuthorisationService(IMapper mapper, IUsersRepository usersRepo,   IOptions<AppSettings> appSettingsOptions)
        {
            _usersRepo = usersRepo;
            _mapper = mapper;
            _appSettings = appSettingsOptions.Value;
        }

        public UserLoginDTO Login(UserLoginDTO userLoginDTO)
        {
            User user = _usersRepo.GetByUsername(userLoginDTO.UserName);

            if (user == null || user.PasswordHash != EncryptionHelper.Encrypt(userLoginDTO.Password, _appSettings.Secret))
            {
                return null;
            }

            if(!user.IsActive){
                throw new ApplicationException("User is not active");
            }

            return new UserLoginDTO
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = JwtHelper.CreateToken(
                    _appSettings.Secret,
                    hoursForTokenToExpire,
                    user.Id,
                    user.UserRoleRelations.Select(ur => ur.Role.Description)
                    )
            };
        }

        [Authorize]
        public void UpdatePassword(UserLoginDTO userLoginDTO)
        {
            User user = _usersRepo.GetByUsername(userLoginDTO.UserName);

            //check old password
            if (EncryptionHelper.Encrypt(userLoginDTO.Password, _appSettings.Secret) != user.PasswordHash)
            {
                throw new ApplicationException("Wrong old password");
            }

            _usersRepo.UpdatePasswordOnly(user.Id, EncryptionHelper.Encrypt(userLoginDTO.NewPassword, _appSettings.Secret));
        }


    }
}

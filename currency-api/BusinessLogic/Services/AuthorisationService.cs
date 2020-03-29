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

        string secretKey;
        double hoursForTokenToExpire = 8;
        public AuthorisationService(IMapper mapper, IUsersRepository usersRepo,   IOptions<AppSettings> appSettingsOptions)
        {
            _usersRepo = usersRepo;

            _mapper = mapper;

            AppSettings appSettings = appSettingsOptions.Value;
            secretKey = appSettings.Secret;
        }

        public UserLoginDTO Login(UserLoginDTO userLoginDTO)
        {
            User user = _usersRepo.GetByUsername(userLoginDTO.UserName);

            if (user == null || user.PasswordHash != EncryptionHelper.Encrypt(userLoginDTO.Password, secretKey))
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
                    secretKey,
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
            if (EncryptionHelper.Encrypt(userLoginDTO.Password, secretKey) != user.PasswordHash)
            {
                throw new ApplicationException("Wrong old password");
            }

            _usersRepo.UpdatePasswordOnly(user.Id, EncryptionHelper.Encrypt(userLoginDTO.NewPassword, secretKey));
        }


    }
}

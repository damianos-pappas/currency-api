
using System;
using System.Linq;
using AutoMapper;
using currencyApi.BusinessLogic.Helpers;
using currencyApi.Data;
using currencyApi.Models;

namespace currencyApi.BusinessLogic
{
    public class AuthorisationService
    {

        IUsersRepository _usersRepo;
        IMapper _mapper;

        string encryptionKey = "this_is_a_demo_project";
        double hoursForTokenToExpire = 8;
        public AuthorisationService(IMapper mapper, IUsersRepository usersRepo)
        {
            _usersRepo = usersRepo;
            _mapper = mapper;
        }

        public UserLoginDTO Login(UserLoginDTO userLoginDTO)
        {
            User user = _usersRepo.GetByUsername(userLoginDTO.UserName);

            if (user == null || user.PasswordHash != EncryptionHelper.Encrypt(userLoginDTO.NewPassword, encryptionKey))
            {
                throw new ApplicationException("Unknown username or password");
            }
            
            return new UserLoginDTO
            {
                UserName = user.UserName,
                Token = JwtHelper.CreateToken(
                    encryptionKey,
                    hoursForTokenToExpire,
                    user.Id,
                    user.UserRoleRelations.Select(ur => ur.Role.Description)
                    )
            };
        }

        public void UpdatePassword(UserLoginDTO userLoginDTO)
        {
            User user = _usersRepo.GetByUsername(userLoginDTO.UserName);

            //check old password
            if (EncryptionHelper.Encrypt(userLoginDTO.Password, encryptionKey) != user.PasswordHash)
            {
                throw new ApplicationException("Wrong old password");
            }

            _usersRepo.UpdatePasswordOnly(user.Id, EncryptionHelper.Encrypt(userLoginDTO.NewPassword, encryptionKey));
        }


    }
}

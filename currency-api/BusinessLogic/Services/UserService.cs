using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using currencyApi.Data;
using currencyApi.Models;


namespace currencyApi.BusinessLogic.Services
{
    public class UserService : IUserService 
    {
        IUsersRepository _usersRepo;
        IMapper _mapper;

        public UserService(IMapper mapper, IUsersRepository usersRepo)
        {
            _usersRepo = usersRepo;
            _mapper = mapper;
        }

        public PagedItems<User> Get( int pageNumber, int pageSize, string sortTerm , bool sortDesc, string searchTerm)
        {
            return _usersRepo.Get( pageNumber, pageSize,  sortTerm, sortDesc,  searchTerm);
        }

        public User Get(long id)
        {
            return _usersRepo.GetOne(id);
        }

        public User Add(UserDTO UserDTO)
        {
            IEnumerable<UserRole> userRoles =  _usersRepo.GetUserRoles(UserDTO.UserRoles);
            
            User user = _mapper.Map<User>(UserDTO);

            _usersRepo.Add(user, userRoles);

            return user;
        }

        public void Delete(long Id, bool safeDelete = false)
        {
            _usersRepo.Delete(Id, safeDelete);
        }
        
        public User UpdateWithoutPassword(UserDTO UserDTO)
        {
             User user = _mapper.Map<User>(UserDTO);

            var newUserRoles = _usersRepo.GetUserRoles(UserDTO.UserRoles);

            _usersRepo.UpdateWithoutPassword(user, newUserRoles);

            return user;
        }

        public IEnumerable<string> GetUserRoles()
        {
            return _usersRepo.GetUserRoles().Select(ur => ur.Description);
        }

        public IEnumerable<UserDTO> MapToDTO(IEnumerable<User> users)
        {
            return users.Select(x => _mapper.Map<UserDTO>(x));
        }

        public UserDTO MapToDTO(User user){
            return _mapper.Map<UserDTO>(user);
        }
    }
}
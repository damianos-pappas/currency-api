using System.Collections.Generic;
using currencyApi.Models;

namespace currencyApi.BusinessLogic.Services
{
    public interface IUserService 
    {
        IEnumerable<User> Get(int pageNumber, int pageSize, string sortTerm , bool sortDesc , string searchTerm);

        User Get(long id);

        User Add(UserDTO entity);

        void Delete(long Id, bool safeDelete = false);

        User UpdateWithoutPassword(UserDTO entity);

        IEnumerable<UserDTO> MapToDTO(IEnumerable<User> users);

        UserDTO MapToDTO(User user);
    }
}
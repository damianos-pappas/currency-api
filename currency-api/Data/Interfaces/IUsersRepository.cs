
using System.Collections.Generic;
using currencyApi.Models;

namespace currencyApi.Data
{
    public interface IUsersRepository //We do not inherit the base repo interface because we only expose Delete from it
    {
        PagedItems<User> Get(int pageNumber, int pageSize, string sortTerm, bool sortDesc, string searchTerm);

        User GetOne(long id);

        IEnumerable<UserRole> GetUserRoles ();

        User GetByUsername(string username);

        IEnumerable<UserRole> GetUserRoles (IEnumerable<string> roleNames);

         void UpdateWithoutPassword(User user, IEnumerable<UserRole> roles);

         void UpdatePasswordOnly(long userId, string passwordHash);

         void Add(User user, IEnumerable<UserRole> roles);

        void Delete(long Id, bool safeDelete = false);
    }
}
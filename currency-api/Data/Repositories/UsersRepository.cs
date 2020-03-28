using currencyApi.Models;

namespace currencyApi.Data
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(IUnitOfWork unitOfWork):base( unitOfWork)
        {
        }
    }
}
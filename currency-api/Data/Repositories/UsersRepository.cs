using currencyApi.Models;

namespace currencyApi.Data
{
    public class UsersRepository : GenericRepository<User>{
        public UsersRepository(IUnitOfWork unitOfWork):base( unitOfWork)
        {
        }
    }
}
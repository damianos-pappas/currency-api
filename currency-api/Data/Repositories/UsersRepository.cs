using System;
using System.Collections.Generic;
using System.Linq;
using currencyApi.Data;
using currencyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace UserApi.Data
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<User> Get(int pageNumber, int pageSize, string sortTerm, bool sortDesc, string searchTerm)
        {
            var result = GetAll();

            result = result.Include(u => u.UserRoleRelations).ThenInclude(ur => ur.Role);

            if (!String.IsNullOrWhiteSpace(searchTerm))
                result = result.Where(x => x.UserName.ToUpper().Contains(searchTerm.ToUpper())
                                            || x.Email.ToUpper().Contains(searchTerm.ToUpper()));

            if (pageNumber > 0 && pageSize > 0)
                result = result.Paginate(pageNumber, pageSize);

            if (!String.IsNullOrWhiteSpace(sortTerm))
                result = result.OrderBy(sortTerm, sortDesc);

            return result.AsEnumerable();
        }

        public User GetOne(long id)
        {
            var result = GetAll();

            result = result.Include(u => u.UserRoleRelations).ThenInclude(ur => ur.Role);

            result = result.Where(x => x.Id == id);

            return result.FirstOrDefault();
        }

        public IEnumerable<UserRole> GetUserRoles(IEnumerable<string> roleNames)
        {
            if (roleNames == null) return new List<UserRole>();

            return _unitOfWork.Context.UserRoles.Where(r => roleNames.Contains(r.Description)).AsEnumerable();
        }

        public IEnumerable<UserRole> GetUserRoles()
        {
            return _unitOfWork.Context.UserRoles.AsEnumerable();
        }

        public override void Update(User user)
        {
            throw new NotSupportedException();
        }

        public void UpdateWithoutPassword(User user, IEnumerable<UserRole> roles)
        {
            base.Update(user);

            var entry = _unitOfWork.Context.Entry(user);

            entry.Property(u => u.PasswordHash).IsModified = false;

            var oldUserRoles = _unitOfWork.Context.UserRoleRelations.Where(r => r.UserId == user.Id);

            _unitOfWork.Context.RemoveRange(oldUserRoles);

            _unitOfWork.Context.AddRange(roles.Select(role => new UserRoleRelation
            {
                UserId = user.Id,
                RoleId = role.Id
            }));
        }

        public void UpdatePasswordOnly(User user)
        {
            User retrievedUser = GetOne(user.Id);
            retrievedUser.PasswordHash = user.PasswordHash;
        }

        public override void Add(User user)
        {
            throw new NotSupportedException();
        }

        public void Add(User user, IEnumerable<UserRole> roles)
        {
            base.Add(user);

            _unitOfWork.Context.AddRange(
                roles.Select(role => new UserRoleRelation
                    {
                        User = user,
                        Role = role
                    })
            );
        }
    }
}
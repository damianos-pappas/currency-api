using System.Collections.Generic;

namespace currencyApi.Models
{
    public class UserRoleRelation : BaseModel
    {
        public long UserId {get;set;}
        public User User {get;set;}
        public long RoleId {get;set;}
        public UserRole Role {get;set;}
    }
}
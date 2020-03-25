using System;
using System.Collections.Generic;

namespace currencyApi.Models
{
    public class User : BaseModel
    {
        public string UserName {get;set;}
        public string Email {get;set;}
        public string PasswordHash {get;set;}
        public DateTime? LockoutEnd {get;set;}
        public bool LockoutEnabled {get;set;}
        public int AccessFailedCount {get;set;}
        public ICollection<UserRoleRelation> UserRoleRelations  {get;set;}
    }
}
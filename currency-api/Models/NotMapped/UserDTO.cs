using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace currencyApi.Models
{
    public class UserDTO
    {
        public long Id {get; set;}
        public string UserName {get;set;}
        public string Email {get;set;}
        public ICollection<string> UserRoles  {get;set;}
        public bool IsActive {get;set;}    
    }
}
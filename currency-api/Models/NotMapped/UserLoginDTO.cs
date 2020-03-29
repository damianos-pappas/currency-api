using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace currencyApi.Models
{
    public class UserLoginDTO
    {
        public string UserName {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
        public string NewPassword {get;set;}
        public string Token {get; set;}
    }
}
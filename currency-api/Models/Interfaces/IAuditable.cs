using System;

namespace currencyApi.Models
{
    interface IAuditable {
        DateTime? CreatedAt {get;set;}
        string CreatedByUser {get;set;}
        DateTime? UpdatedAt {get;set;}
        string UpdatedByUser {get;set;}
    }
}

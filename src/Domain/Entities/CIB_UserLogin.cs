using CleanApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanApp.Domain.Entities
{
    public class CIB_UserLogin : BaseEntity
    {
        public string RegisteredNumber { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string LoggedInDevice { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

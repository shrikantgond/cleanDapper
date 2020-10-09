using System;
using System.Collections.Generic;
using System.Text;

namespace CleanApp.Application.Authentication.Commands
{
    public class RegisterInputDTO
    {
        //public string RegisteredNumber { get; set; }
        public string RegisteredNumber { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string LoggedInDevice { get; set; }

    }
}

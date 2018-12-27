using System;
using System.Collections.Generic;
using System.Text;

namespace Status.DomainModel.Response
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string Token { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Status.DomainModel.Requests
{
    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] ProfilePic { get; set; }
    }
}

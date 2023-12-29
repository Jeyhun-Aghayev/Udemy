using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.BUSINESS.Exceptions.User
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("There is no such user.") { }
        public UserNotFoundException(string? message) : base(message) { }
    }
}

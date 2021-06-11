using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ICurrentUserService
    {
        int UserId { get; }
        bool IsAuthticated { get; }
        string Email { get; }
        string FullName { get; }
        string FirstName { get; }
        string LastName { get; }
        DateTime DateOfBirth { get; }
        bool IsAdmin { get; }
        IEnumerable<string> Roles { get; }
    }
}

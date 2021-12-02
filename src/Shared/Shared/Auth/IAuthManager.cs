using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Auth
{
    public interface IAuthManager
    {
        JsonWebToken CreateToken(string userId, string role = null, string audience = null,IDictionary<string, IEnumerable<string>> claims = null);
    }
}

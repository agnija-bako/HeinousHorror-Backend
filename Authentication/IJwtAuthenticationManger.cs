using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace heinousHorror
{
   public interface IJwtAuthenticationManger
    {
        string Authenticate(string username, string password);

    }
}

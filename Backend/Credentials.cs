using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Auth;

public struct Credentials
{
    public string Username { get; } = string.Empty;
    internal Credentials(string username)
    {
        Username = username;
    }  
}

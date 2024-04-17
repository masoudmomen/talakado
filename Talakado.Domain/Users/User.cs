using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Domain.Attributes;

namespace Talakado.Domain.Users
{
    [Auditable]
    public class User:IdentityUser
    {
        public string FullName { get; set; }
    }
}

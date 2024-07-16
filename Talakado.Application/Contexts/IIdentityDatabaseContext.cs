using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Domain.Users;

namespace Talakado.Application.Contexts
{
    public interface IIdentityDataBaseContext
    {
        DbSet<User> Users { get; set; }
    }
}

using SecretService.Data;
using SecretService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SecretService.Services
{
    public class UserService : Repository<User>
    {
        public UserService(SecretServiceContext context) : base(context.Users)
        {

        }

        public override IEnumerable<User> Get()
        {
            return Query(q => true).Include(q => q.Routes);
        }
    }
}

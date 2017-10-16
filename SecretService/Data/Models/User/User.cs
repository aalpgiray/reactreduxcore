using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SecretService.Data
{
    public class User : Base
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public UserRole UserRole { get; set; }
        public List<Route> Routes { get; set; }
    }

}

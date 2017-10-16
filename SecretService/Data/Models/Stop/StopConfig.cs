using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecretService.Data
{
    public class StopConfig : BaseConfiguration<Stop>
    {
        public override void Configure(EntityTypeBuilder<Stop> builder)
        {
            base.Configure(builder);

            builder.HasOne(q => q.Route).WithMany(q => q.Stops);
            builder.HasOne(q => q.Geometry);
            builder.Ignore(q => q.Geometry);
        }
    }
}

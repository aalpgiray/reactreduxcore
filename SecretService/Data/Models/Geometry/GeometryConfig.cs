using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecretService.Data
{
    public class GeometryConfig : BaseConfiguration<Geometry>
    {
        public override void Configure(EntityTypeBuilder<Geometry> builder)
        {
            base.Configure(builder);

            builder.Ignore(q => q.Shape);
        }
    }
}

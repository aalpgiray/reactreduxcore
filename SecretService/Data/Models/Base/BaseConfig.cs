using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretService.Data
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : Base
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(q => q.Id);
            builder.HasQueryFilter(q => !q.IsDeleted);
        }
    }

}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SecretService.Data
{
    public class UserConfig : BaseConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(q => q.Name).IsRequired();
            builder.Property(q => q.Surname).IsRequired();
            builder.Property(q => q.UserName).IsRequired();
        }
    }
}

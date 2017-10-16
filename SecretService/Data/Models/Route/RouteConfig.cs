using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SecretService.Data
{
    public class RouteConfig : BaseConfiguration<Route>
    {
        public override void Configure(EntityTypeBuilder<Route> builder)
        {
            base.Configure(builder);

            builder.HasOne(q => q.Requester).WithMany(q => q.Routes);
        }
    }
}

namespace Web.Site.User.Infrastructure.Persistence.NHibernate.Mapping
{
    using FluentNHibernate.Mapping;

    public class RoleMap : ClassMap<Domain.Entity.Role>
    {
        public RoleMap()
        {
            Id(x => x.Id).Column("role_id");
            Map(x => x.Name).Column("role_name");  
        }
    }
}

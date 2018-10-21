namespace Web.Site.User.Infrastructure.Persistence.NHibernate.Mapping
{
    using FluentNHibernate.Mapping;
    using Domain.Entity;

    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id).Column("user_id");
            Map(x => x.UserName).Column("user_name");
            Map(x => x.Password).Column("password");
            References(x => x.Role).Not.LazyLoad();
        }
    }
}

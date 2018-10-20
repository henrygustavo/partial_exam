namespace Web.Site.User.Domain.Repository
{
    using Web.Site.Common.Domain.Repository;
    using Web.Site.User.Domain.Entity;

    public interface IRoleRepository : IRepository<Role>
    {
        Role GetByName(string name);
    }
}

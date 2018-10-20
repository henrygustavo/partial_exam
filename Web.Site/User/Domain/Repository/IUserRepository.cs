using Web.Site.Common.Domain.Repository;

namespace Web.Site.User.Domain.Repository
{
    using Web.Site.User.Domain.Entity;
    public interface IUserRepository : IRepository<User>
    {
        User GetByName(string userName);
    }
}

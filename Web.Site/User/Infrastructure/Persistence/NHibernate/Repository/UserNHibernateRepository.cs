namespace Web.Site.User.Infrastructure.Persistence.NHibernate.Repository
{
    using Web.Site.Common.Infrastructure.Persistence.NHibernate;
    using Web.Site.User.Domain.Repository;
    using Web.Site.User.Domain.Entity;
    public class UserNHibernateRepository  : BaseNHibernateRepository<User>, IUserRepository
    {
        public UserNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }
    }
}

namespace Web.Site.User.Infrastructure.Persistence.NHibernate.Repository
{
    using Web.Site.Common.Infrastructure.Persistence.NHibernate;
    using Web.Site.User.Domain.Repository;
    using Web.Site.User.Domain.Entity;
    using System.Linq;

    public class UserNHibernateRepository  : BaseNHibernateRepository<User>, IUserRepository
    {
        public UserNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }

        public User GetByName(string userName)
        {
            bool status = _unitOfWork.BeginTransaction();
            User entity = _unitOfWork.GetSession().Query<User>().Where(
                p => p.UserName.ToLower() == userName.ToLower()).SingleOrDefault();
            _unitOfWork.Commit(status);
            return entity;
        }
    }
}

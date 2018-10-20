namespace Web.Site.User.Infrastructure.Persistence.NHibernate.Repository
{
    using Web.Site.Common.Infrastructure.Persistence.NHibernate;
    using Web.Site.User.Domain.Repository;
    using Web.Site.User.Domain.Entity;
    using System.Linq;

    public class RoleNHibernateRepository : BaseNHibernateRepository<Role>, IRoleRepository
    {
        public RoleNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }

        public Role GetByName(string name)
        {
            bool status = _unitOfWork.BeginTransaction();
            Role entity = _unitOfWork.GetSession().Query<Role>()
                .Where(p=>p.Name == name).SingleOrDefault();
            _unitOfWork.Commit(status);
            return entity;
        }
    }
}

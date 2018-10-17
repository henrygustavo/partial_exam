namespace Web.Site.Product.Infrastructure.Persistence.NHibernate.Repository
{
    using Web.Site.Common.Infrastructure.Persistence.NHibernate;
    using Web.Site.Product.Domain.Repository;
    using Domain.Entity;

    public class CategoryNHibernateRepository : BaseNHibernateRepository<Category>, ICategoryRepository
    {
        public CategoryNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }
    }
}

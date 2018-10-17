namespace Web.Site.Template.Infrastructure.Persistence.NHibernate.Repository
{
    using Web.Site.Common.Infrastructure.Persistence.NHibernate;
    using Web.Site.Template.Domain.Repository;
    using Domain.Entity;


    public class TemplateNHibernateRepository : BaseNHibernateRepository<Template>, ITemplateRepository
    {
        public TemplateNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }
    }
}

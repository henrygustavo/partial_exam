namespace Web.Site.Product.Infrastructure.Persistence.NHibernate.Repository
{
    using Web.Site.Common.Infrastructure.Persistence.NHibernate;
    using Web.Site.Product.Domain.Repository;
    using Domain.Entity;
    using System.Collections.Generic;
    using Web.Site.Api.Common.Domain.Specification;
    using System.Linq;
    public class ProductNHibernateRepository : BaseNHibernateRepository<Product>, IProductRepository
    {
        public ProductNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
            
        }

        public IReadOnlyList<Product> GetFilteredList(Specification<Product> specification)
        {
            bool status = _unitOfWork.BeginTransaction();
            IReadOnlyList<Product> entities = _unitOfWork.GetSession().Query<Product>()
                .Where(specification.ToExpression()).ToList();
            _unitOfWork.Commit(status);
            return entities;
        }
    }
}

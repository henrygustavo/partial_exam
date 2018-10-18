namespace Web.Site.Api.Common.Domain.Specification
{
    using System;
    using System.Linq.Expressions;

    internal sealed class  IdentitySpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> ToExpression()
        {
            return x => true;
        }
    }
}

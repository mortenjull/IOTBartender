using IOTBartender.Domain.Entititeis;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IOTBartender.Domain.UnitOfWorks.Repositories
{
    public interface IExpSpecification<TEntity>
         : ISpecification<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// Criteria for the specification.
        /// </summary>
        Expression<Func<TEntity, bool>> Criteria { get; }
    }
}

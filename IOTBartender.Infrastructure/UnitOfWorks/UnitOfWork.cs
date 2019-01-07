using IOTBartender.Domain.UnitOfWorks;
using IOTBartender.Domain.UnitOfWorks.Repositories;
using IOTBartender.Infrastructure.UnitOfWorks.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IOTBartender.Infrastructure.UnitOfWorks
{
    public class UnitOfWork<TDbContext>
        : IUnitOfWork where TDbContext : DbContext
    {
        /// <summary>
        /// DbContext which is used for repositories
        /// and save of entities.
        /// </summary>
        private readonly TDbContext _dbContext;

        /// <summary>
        /// Constructs an UnitOfWork which is using entity
        /// framework core to save entities and changes.
        /// </summary>
        /// <param name="dbContext">DbContext to use for storing changes.</param>
        public UnitOfWork(TDbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException(nameof(dbContext));

            this._dbContext = dbContext;

            // Create repository.
            this.Repository = new Repository(this._dbContext);
        }

        public IRepository Repository { get; }

        public async Task<int> SaveChanges(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                return await this._dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException exception)
            {
                throw new Exception("Entity Framework Core SaveChanges faild.", exception);
            }
        }
    }
}

using System;
using System.Threading.Tasks;


namespace Microsoft.EntityFrameworkCore
{
    public static class DbContextHelper
    {
        public static Func<DbContextOptions<TDbContext>, Task<TDbContext>> GetAsynchronousConstructor<TDbContext>(
            Func<DbContextOptions<TDbContext>, TDbContext> synchronousConstructor)
            where TDbContext : DbContext
        {
            Task<TDbContext> AsynchronousConstructor(DbContextOptions<TDbContext> dbContextOptions)
            {
                var dbContext = synchronousConstructor(dbContextOptions);

                return Task.FromResult(dbContext);
            }

            return AsynchronousConstructor;
        }
    }
}

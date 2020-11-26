using Ensek.Test.Domain.Entities;
using Ensek.Test.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensek.Test.Infrastructure.Repositories
{
    public interface IMeterReadingRepository
    {
        Task<int> AddRange(ICollection<MeterReading> entities, CancellationToken cancellationToken = default);
    }
    public class MeterReadingRepository : IMeterReadingRepository
    {
        public ApplicationDbContext Context { get; set; }

        public MeterReadingRepository(ApplicationDbContext context)
        {
            Context = context;
        }
        public async Task<int> AddRange(ICollection<MeterReading> entities, CancellationToken cancellationToken = default)
        {
            Context.AddRange(entities);
            return await Context.SaveChangesAsync(cancellationToken); 
        }
    }
}

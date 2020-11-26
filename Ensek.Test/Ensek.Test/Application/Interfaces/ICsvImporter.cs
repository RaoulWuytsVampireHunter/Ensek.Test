using Ensek.Test.Application.Utils.Csv;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensek.Test.Application.Interfaces
{
    public interface ICsvImporter
    {
        Task<List<MeterReadingImportDto>> ReadCsvAsync(IFormFileCollection files, CancellationToken ct = default(CancellationToken));
    }
}

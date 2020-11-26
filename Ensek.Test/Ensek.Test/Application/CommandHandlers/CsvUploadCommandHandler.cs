using Ensek.Test.Application.Commands;
using Ensek.Test.Application.Interfaces;
using Ensek.Test.Application.Models;
using Ensek.Test.Domain.Entities;
using Ensek.Test.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ensek.Test.Application.CommandHandlers
{
    public class CsvUploadCommandHandler : IRequestHandler<CsvUploadCommand, CsvResponse>
    {
        private readonly ICsvImporter importer;
        private readonly IMeterReadingRepository repository;

        public CsvUploadCommandHandler(ICsvImporter importer, IMeterReadingRepository repository)
        {
            this.importer = importer;
            this.repository = repository;
        }
        public async Task<CsvResponse> Handle(CsvUploadCommand command, CancellationToken cancellationToken)
        {
            var files = command.Files;

            var csvLines = await importer.ReadCsvAsync(files, cancellationToken);

            var entities = new List<MeterReading>();

            int succeeded = 0;
            int failed = 0;

            foreach (var row in csvLines)
            {
                var entity = new MeterReading();

                if ( !int.TryParse(row.AccountId, out int accountId) ||
                     !DateTime.TryParse(row.MeterReadingDateTime, out DateTime readingDateTime) ||
                     !(row.MeterReadValue.Length == 5) ||
                     !int.TryParse(row.MeterReadValue, out int readingValue))
                {
                    failed++;
                    continue;
                }

                entity.AccountId = accountId;
                entity.Value = readingValue;
                entity.ReadingDateTime = readingDateTime;

                succeeded++;
                entities.Add(entity);
            }

            if (entities.Count > 0)
            {
                await repository.AddRange(entities);
            }

            return new CsvResponse(succeeded, failed);
        }
    }
}

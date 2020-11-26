using Ensek.Test.Application.Commands;
using Ensek.Test.Application.Interfaces;
using Ensek.Test.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ensek.Test.Application.CommandHandlers
{
    public class CsvUploadCommandHandler : IRequestHandler<CsvUploadCommand, Response>
    {
        private readonly ICsvImporter importer;

        public CsvUploadCommandHandler(ICsvImporter importer)
        {
            this.importer = importer;
        }
        public async Task<Response> Handle(CsvUploadCommand command, CancellationToken cancellationToken)
        {
            var files = command.Files;

            var list = await importer.ReadCsvAsync(files, cancellationToken);



            return new Response(true);
        }
    }
}

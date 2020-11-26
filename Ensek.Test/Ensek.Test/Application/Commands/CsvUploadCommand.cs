using Ensek.Test.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Ensek.Test.Application.Commands
{
    public class CsvUploadCommand : IRequest<CsvResponse>
    {
        public IFormFileCollection Files { get; }

        public CsvUploadCommand(IFormFileCollection files)
        {
            Files = files;
        }
    }
}

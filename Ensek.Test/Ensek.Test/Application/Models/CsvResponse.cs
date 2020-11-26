using MediatR;

namespace Ensek.Test.Application.Models
{
    public class CsvResponse : IRequest
    {
        public int Succeeded { get; }
        public int Failed { get;  }

        public CsvResponse(int succeeded, int failed)
        {
            Succeeded = succeeded;
            Failed = failed;
        }
    }
}

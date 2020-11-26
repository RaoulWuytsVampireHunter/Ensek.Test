using MediatR;

namespace Ensek.Test.Application.Models
{
    public class Response : IRequest
    {
        public bool Succes { get; set; }

        public Response(bool succes)
        {
            Succes = succes;
        }
    }
}

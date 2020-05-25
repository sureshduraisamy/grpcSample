using Grpc.Core;
using Grpc.Server.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.Server.Person
{
    public class PersonService : Person.PersonBase
    {
        private readonly ILogger<PersonService> _logger;
        private readonly IMediator _mediater;

        public PersonService(ILogger<PersonService> logger, IMediator mediater)
        {
            _logger = logger;
            _mediater = mediater;
        }

        public override Task<PersonResponse> GetPersonById(PersonSearchRequest request, ServerCallContext context)
        {
            var query = new GetPersonByIdQuery(request.Id);
            var result = Task.FromResult(_mediater.Send(query));
            return Task.FromResult(new PersonResponse
            {
                Id = 1,
                Firstname = "FirstName",
                Lastname = "Lastname",
            });

        }
    }
}

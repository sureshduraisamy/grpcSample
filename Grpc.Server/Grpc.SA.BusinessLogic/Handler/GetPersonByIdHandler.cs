using Grpc.SA.BusinessLogic.Queries;
using Grpc.SA.BusinessLogic.Responses;
using Grpc.SA.DAL.Models;
using Grpc.SA.DAL.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Grpc.SA.BusinessLogic.Handler
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonResponse>
    {
        private readonly PersonRepository _personRepository;
        public GetPersonByIdHandler(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<PersonResponse> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
           var result =  await _personRepository.GetPersonByIdAsync(request.Id);

            return result == null ? null : new PersonResponse {  
            Id = 1,
            FirstName = "test",
            LastName ="last"} ;
        }
    }
}

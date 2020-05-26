using Grpc.Server.Queries;
using Grpc.Server.Responses;
using Grpc.SA.DAL.Models;
using Grpc.SA.DAL.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Grpc.SA.DAL.IRepository;
using Grpc.SA.DAL.IServiceProviders;

namespace Grpc.Server.Handler
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonResponse>
    {
        private  IPersonServiceProvider _personServiceProvider;
        public GetPersonByIdHandler(IPersonServiceProvider personServiceProvider)
        {
            _personServiceProvider = personServiceProvider;
        }

        public async Task<PersonResponse> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
           var result =  await _personServiceProvider.GetPersonByIdAsync(request.Id);

            return result == null ? null : new PersonResponse {  
            Id = 1,
            FirstName = "test",
            LastName ="last"} ;
        }
    }
}

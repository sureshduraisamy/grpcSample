using Grpc.SA.BusinessLogic.Responses;
using Grpc.SA.DAL.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grpc.SA.BusinessLogic.Queries
{
    public class GetPersonByIdQuery : IRequest<PersonResponse>
    {
        public int Id { get; set; }

        public GetPersonByIdQuery(int id)
        {
            Id = id;
        }
    }
}

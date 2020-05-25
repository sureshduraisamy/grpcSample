using System;
using System.Collections.Generic;
using System.Text;

namespace Grpc.Server.Responses
{
    public class PersonResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

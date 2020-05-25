using Grpc.SA.DAL.Context;
using Grpc.SA.DAL.IRepository;
using Grpc.SA.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grpc.SA.DAL.Repositories
{
    public class PersonRepository: IPersonRepository
    {
        private  PersonContext _personDBContext;
        public PersonRepository(PersonContext personContext)
        {
            _personDBContext = personContext;        
        }

        public Task<Person> GetPersonByIdAsync(int personId)
        {
            return Task.FromResult(_personDBContext.People.SingleOrDefault(x => x.Id == personId));
        }

        public Task<List<Person>> GetPersonsAsync()
        {
            return Task.FromResult(_personDBContext.People.ToList());
        }
    }
}

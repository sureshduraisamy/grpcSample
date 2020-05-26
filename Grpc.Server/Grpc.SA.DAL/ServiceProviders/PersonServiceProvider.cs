using Grpc.SA.DAL.IRepository;
using Grpc.SA.DAL.IServiceProviders;
using Grpc.SA.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grpc.SA.DAL.ServiceProviders
{
    public class PersonServiceProvider : IPersonServiceProvider
    {
        private readonly IPersonRepository _personRepository;
        public PersonServiceProvider(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> GetPersonByIdAsync(int personId)
        {
            var result =  await _personRepository.GetPersonByIdAsync(personId);
            //To Do : Write any business Logic if needed
            return result;
        }

        public async Task<List<Person>> GetAllPersonsAsync()
        {
            var result = await _personRepository.GetPersonsAsync();
            //To Do : Write any business Logic if needed
            return result;
        }
    }
}

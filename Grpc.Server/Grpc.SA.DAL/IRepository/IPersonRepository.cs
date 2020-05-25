using Grpc.SA.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grpc.SA.DAL.IRepository
{
    public interface IPersonRepository
    {
        Task<Person> GetPersonByIdAsync(int personId);

        Task<List<Person>> GetPersonsAsync();
        
    }
}

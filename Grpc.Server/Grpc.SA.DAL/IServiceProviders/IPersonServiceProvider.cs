using Grpc.SA.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grpc.SA.DAL.IServiceProviders
{
    public interface IPersonServiceProvider 
    {
        Task<Person> GetPersonByIdAsync(int personId);

        Task<List<Person>> GetAllPersonsAsync();
    }
}

using Grpc.SA.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grpc.SA.DAL.Context
{
    public partial class PersonContext : DbContext , IPersonContext
    {
        public PersonContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Person> People { get; set; }

        public DbSet<Address> Addresses { get; set; }
    }
}

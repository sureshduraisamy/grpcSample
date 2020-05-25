using Grpc.Net.Client;
using Grpc.Server;
using Grpc.Server.Person;
using System;
using System.Threading.Tasks;

namespace Grpc.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //creating the channel with GRPC server URL
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            //Creating the Client Instance of Greeter Server using the channel
            var client = new Greeter.GreeterClient(channel);
            //Consuming the Grpc Server Service using RPC call from Grpc Client 
            HelloReply respone = await client.SayHelloAsync(new HelloRequest { Name = "SafeAuto" });
            Console.WriteLine($"{respone.Message}");

            var client1 = new Person.PersonClient(channel);
            PersonResponse response = await client1.GetPersonByIdAsync(new PersonSearchRequest { Id = 1 });
            Console.WriteLine($"{response.Id}-{response.Firstname}-{response.Lastname}");
            Console.ReadLine();
        }
    }
}

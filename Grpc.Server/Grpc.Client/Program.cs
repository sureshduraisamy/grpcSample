using Grpc.Net.Client;
using Grpc.Server;
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

            Console.ReadLine();
        }
    }
}

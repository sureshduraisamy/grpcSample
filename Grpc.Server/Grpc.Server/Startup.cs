using Grpc.SA.DAL.Context;
using Grpc.SA.DAL.IRepository;
using Grpc.SA.DAL.IServiceProviders;
using Grpc.SA.DAL.Repositories;
using Grpc.SA.DAL.ServiceProviders;
using Grpc.Server.Handler;
using Grpc.Server.Person;
using Grpc.Server.Queries;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Grpc.Server
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //Adding Dependency Injection for DBContext
            services.AddDbContext<PersonContext>(options =>
            {
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddMediatR(typeof(GetPersonByIdQuery).GetTypeInfo().Assembly);
            services.AddScoped(typeof(IPersonRepository), typeof(PersonRepository));
            services.AddScoped(typeof(IPersonServiceProvider), typeof(PersonServiceProvider));
            //services.AddMediatR(typeof(Startup).Assembly);

            services.AddGrpc();


            //Adding Db Context For Repositories
            //services.AddSingleton<IPersonRepository, PersonRepository>();
            
            
            
            //services.AddTransient<IRequestHandler<GetPersonByIdQuery, PersonResponse>, GetPersonByIdHandler>(); // Mediator dependency injection request


            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("v1",
            //        new Microsoft.OpenApi.Models.OpenApiInfo
            //        {
            //            Title ="Swagger Demo API",
            //            Description = "Demo API for showing Swagger",
            //            Version="v1"

            //        });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<GreeterService>();
                endpoints.MapGrpcService<PersonService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });

            //app.UseSwagger();
            //app.UseSwaggerUI(options => {

            //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo API");
            //});
        }
    }
}

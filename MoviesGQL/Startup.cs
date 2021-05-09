using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoviesGQL.GraphQL;
using MoviesGQL.Models;
using MoviesGQL.Services;
using System;

namespace MoviesGQL
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            #region Connection String  
            String conn = Configuration.GetConnectionString("AzureConnection");
            services.AddDbContext<MoviesContext>(item => item.UseSqlServer(Configuration.GetConnectionString("AzureConnection")));
            #endregion

            services.AddScoped<Query>();
            services.AddScoped<Mutation>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddGraphQL(c => SchemaBuilder.New().AddServices(c).AddType<GraphQLTypes>()
                                                                        .AddQueryType<Query>()
                                                                        .AddMutationType<Mutation>()
                                                                         .Create()
                                                                         );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGraphQL("/api");
            app.UsePlayground(new PlaygroundOptions
            {
                QueryPath = "/api",
                Path = "/playground"
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Add \"/playground\" to the url to play with GraphQL");
                });
            });
        }
    }
}

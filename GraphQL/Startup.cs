using System;
using HotChocolate.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RecruitmentBuddy.GraphQL.Applicants;
using RecruitmentBuddy.GraphQL.Data;
using RecruitmentBuddy.GraphQL.DataLoader;
using RecruitmentBuddy.GraphQL.Jobs;
using RecruitmentBuddy.GraphQL.Types;

namespace RecruitmentBuddy.GraphQL
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<ApplicationDbContext>(options => options.UseSqlite("Data Source=recruitment.db"));
            
            services
                .AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                    .AddTypeExtension<ApplicantQueries>()
                    .AddTypeExtension<JobQueries>()
                .AddMutationType( d => d.Name("Mutation"))
                    .AddTypeExtension<ApplicantMutations>()
                    .AddTypeExtension<JobMutations>()
                .AddType<ApplicantType>()
                .AddType<JobType>()
                .EnableRelaySupport()
                .AddFiltering()
                .AddSorting()
                .AddInMemorySubscriptions()
                .AddDataLoader<ApplicantByIdDataLoader>()
                .AddDataLoader<JobByIdDataLoader>();
            
            // CORS
            var origins = new string[] { "http://localhost", "http://localhost:3001", "http://localhost:3000" };
            
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins(origins)
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseWebSockets();
            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}

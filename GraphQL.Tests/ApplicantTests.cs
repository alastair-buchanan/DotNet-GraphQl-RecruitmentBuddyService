using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecruitmentBuddy.GraphQL.Applicants;
using RecruitmentBuddy.GraphQL.Data;
using RecruitmentBuddy.GraphQL.Types;
using Snapshooter.Xunit;
using Xunit;

namespace GraphQL.Tests;

public class ApplicantTests
{
    [Fact]
        public async Task Applicant_Schema_Changed()
        {
            // arrange
            // act
            ISchema schema = await new ServiceCollection()
                .AddPooledDbContextFactory<ApplicationDbContext>(
                    options => options.UseInMemoryDatabase("Data Source=recruitment.db"))
                .AddGraphQL()
                .AddQueryType(d => d.Name("Query"))
                .AddTypeExtension<ApplicantQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                .AddTypeExtension<ApplicantMutations>()
                .AddType<ApplicantType>()
                .EnableRelaySupport()
                .BuildSchemaAsync();
            
            // assert
            schema.Print().MatchSnapshot();
        }
        
        /*[Fact]
        public async Task RegisterApplicant()
        {
            // arrange
            IRequestExecutor executor = await new ServiceCollection()
                .AddPooledDbContextFactory<ApplicationDbContext>(
                    options => options.UseInMemoryDatabase("Data Source=recruitment.db"))
                .AddGraphQL()
                .AddQueryType(d => d.Name("Query"))
                .AddTypeExtension<ApplicantQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                .AddTypeExtension<ApplicantMutations>()
                .AddType<ApplicantType>()
                .EnableRelaySupport()
                .BuildRequestExecutorAsync();

            // act
            IExecutionResult result = await executor.ExecuteAsync(@"
            mutation RegisterApplicant{
                registerApplicant(
                    input: {
                        emailAddress: ""michael@chillicream.com""
                            firstName: ""michael""
                            lastName: ""staib""
                            userName: ""michael3""
                        })
                {
                    applicant {
                        id
                    }
                }
            }");

            // assert
            result.ToJson().MatchSnapshot();
        }*/
}
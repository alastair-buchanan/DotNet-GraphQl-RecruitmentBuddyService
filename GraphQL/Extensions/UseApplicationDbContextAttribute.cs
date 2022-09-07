using System.Reflection;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using RecruitmentBuddy.GraphQL.Data;

namespace RecruitmentBuddy.GraphQL.Extensions
{
    public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            descriptor.UseDbContext<ApplicationDbContext>();
        }
    }
}
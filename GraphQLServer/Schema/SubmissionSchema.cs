using Microsoft.Extensions.DependencyInjection;
using System;

namespace GraphQLServer.Schema
{
    public class SubmissionSchema : GraphQL.Types.Schema
    {
        public SubmissionSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<RootQuery>();
            Mutation = serviceProvider.GetRequiredService<Mutation>();
        }
    }
}

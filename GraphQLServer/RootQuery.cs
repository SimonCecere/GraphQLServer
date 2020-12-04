using GraphQL;
using GraphQL.Types;
using GraphQLServer.DAL;
using GraphQLServer.DbModels;
using GraphQLServer.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer
{
    public class RootQuery : ObjectGraphType<object>
    {
        public RootQuery(ApplicationContext applicationContext)
        {
            Name = "RootQuery";

            Field<ListGraphType<SubmissionType>>(
                "submissions",
                resolve: context => applicationContext.Submission
                );

            Field<SubmissionType>(
                "Submission",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id" }
                    ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return applicationContext.Submission.FirstOrDefault(m => m.Id == id);
                }
                );
        }
    }
}

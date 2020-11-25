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
    public class SubmissionQuery : ObjectGraphType<object>
    {
        public SubmissionQuery(ApplicationContext applicationContext)
        {
            Field<ListGraphType<SubmissionType>>(
                "submissions",
                "",
                resolve: context => applicationContext.Submission
                );
        }
    }
}

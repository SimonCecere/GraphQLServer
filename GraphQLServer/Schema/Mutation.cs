using GraphQL;
using GraphQL.Types;
using GraphQLServer.DAL;
using GraphQLServer.DbModels;
using GraphQLServer.Schema.InputTypes;
using GraphQLServer.Schema.Types;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Schema
{
    public class Mutation : ObjectGraphType
    {
        public Mutation(ApplicationContext applicationContext)
        {
            Name = "Mutation";

            Field<SubmissionType>(
                "createSubmission",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<SubmissionInputType>> { Name = "submission" }
                ),
                resolve: context =>
                {
                    var submission = context.GetArgument<Submission>("submission");

                    //Add some systematic things
                    submission.DateTime = DateTime.Now;
                    submission.Status = "PENDING"; //Passes validation

                    applicationContext.Add(submission);
                    applicationContext.SaveChanges();

                    return submission;
                });

        }
    }
}

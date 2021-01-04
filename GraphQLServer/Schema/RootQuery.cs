using GraphQL;
using GraphQL.Types;
using GraphQLServer.DAL;
using GraphQLServer.Schema.Types;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLServer.Schema
{
    public class RootQuery : ObjectGraphType<object>
    {
        public RootQuery(ApplicationContext applicationContext)
        {
            Name = "RootQuery";

            //Submission Query's
            //----------------------------
            Field<SubmissionType>(
                "Submission",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                    ),
                resolve: context =>
                {
                    var id = context.GetArgument<int?>("id");

                    //Create query with EF Core Linq 
                    var submission = applicationContext.Submission.AsQueryable();

                    if (id.HasValue)
                    {
                        submission.Where(m => m.Id == id);
                    }

                    return submission.FirstOrDefault(m => m.Id == id);
                }
                );

            Field<ListGraphType<SubmissionType>>(
                "Submissions",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "email" },
                    new QueryArgument<StringGraphType> { Name = "firstName" },
                    new QueryArgument<StringGraphType> { Name = "lastName" },
                    new QueryArgument<StringGraphType> { Name = "address" },
                    new QueryArgument<StringGraphType> { Name = "city" },
                    new QueryArgument<StringGraphType> { Name = "state" },
                    new QueryArgument<StringGraphType> { Name = "postalCode" },
                    new QueryArgument<StringGraphType> { Name = "countryCode" },
                    new QueryArgument<StringGraphType> { Name = "status" }
                    ),
                resolve: context => {

                    //Build query
                    var queryString = "Select * from Submission";
                    var paramiters = new List<SqlParameter>();

                    foreach ((var argument, int index) in context.Arguments.Select((argument, index) => (argument, index)))
                    {
                        if (!(argument.Value == null || (string)argument.Value == string.Empty))
                        {
                            if (!queryString.Contains("where"))
                                queryString += $" where";
                            else
                                queryString += $" and";

                            queryString +=$" {argument.Key} = @{index}Value";

                            paramiters.Add(new SqlParameter($"@{index}Value", argument.Value.ToString()));
                        }
                    }
                    return applicationContext.Submission.FromSqlRaw(queryString, paramiters.ToArray());
                    }
                );


            //Products Query's
            //----------------------------
            Field<ProductType>(
                "Product",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id" }
                    ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return applicationContext.Product.FirstOrDefault(m => m.Id == id);
                }
                );

            Field<ListGraphType<ProductType>>(
                "Products",
                resolve: context => applicationContext.Product
                );
        }
    }
}

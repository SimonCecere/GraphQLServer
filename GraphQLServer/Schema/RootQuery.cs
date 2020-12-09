using GraphQL;
using GraphQL.Types;
using GraphQLServer.DAL;
using GraphQLServer.Schema.Types;
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
                    var id = context.GetArgument<int>("id");
                    return applicationContext.Submission.FirstOrDefault(m => m.Id == id);
                }
                );

            Field<ListGraphType<SubmissionType>>(
                "Submissions",
                resolve: context => applicationContext.Submission
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

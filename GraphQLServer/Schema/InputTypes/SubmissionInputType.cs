using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Schema.InputTypes
{
    public class SubmissionInputType : InputObjectGraphType
    {
        public SubmissionInputType()
        {
            Name = "SubmissionInput";
            Field<NonNullGraphType<StringGraphType>>("submissionId");
            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
            Field<NonNullGraphType<StringGraphType>>("address1");
            Field<NonNullGraphType<StringGraphType>>("address2");
            Field<NonNullGraphType<StringGraphType>>("city");
            Field<NonNullGraphType<StringGraphType>>("state");
            Field<NonNullGraphType<StringGraphType>>("postalCode");
            Field<NonNullGraphType<StringGraphType>>("countryCode");
            Field<NonNullGraphType<StringGraphType>>("email");
            Field<StringGraphType>("phone");
            Field<NonNullGraphType<ListGraphType<ItemOrderInputType>>>("itemOrders");
        }
    }
}

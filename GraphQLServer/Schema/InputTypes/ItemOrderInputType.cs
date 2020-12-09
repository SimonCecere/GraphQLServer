using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Schema.InputTypes
{
    public class ItemOrderInputType : InputObjectGraphType
    {
        public ItemOrderInputType()
        {
            Name = "ItemOrderInput";
            Field<NonNullGraphType<IdGraphType>>("productId");
            Field<NonNullGraphType<IntGraphType>>("quantity");
        }
    }
}

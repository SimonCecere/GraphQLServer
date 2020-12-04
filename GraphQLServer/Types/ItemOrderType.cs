using GraphQL.Types;
using GraphQLServer.DAL;
using GraphQLServer.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Types
{
    public class ItemOrderType : ObjectGraphType<ItemOrder>
    {
        public ItemOrderType(ApplicationContext applicationContext)
        {
            Name = "ItemOrder";
            Description = "A item order for a submission.";
            Field(x => x.Id).Description("The Id of the item order.");
            Field(x => x.QTY).Name("quantity").Description("The quantity of the product for the item order.");
            
            Field<ProductType>()
                .Name("Product")
                .Description("The product of the item order.").Resolve((context) => {
                return applicationContext.Product.FirstOrDefault(x => x.Id == context.Source.ProductId);
            });
        }
    }
}

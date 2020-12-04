using GraphQL.Types;
using GraphQLServer.DAL;
using GraphQLServer.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(ApplicationContext applicationContext)
        {
            Name = "Product";
            Description = "A product of an item order";
            Field(x => x.Id).Description("The Id of the product.");
            Field(x => x.Description).Description("The Description of the product.");
            Field(x => x.SKU).Name("sku").Description("The sku number of the product.");
        }
    }
}

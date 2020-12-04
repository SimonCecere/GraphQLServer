using GraphQL.Types;
using GraphQLServer.DAL;
using GraphQLServer.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Types
{
    public class SubmissionType : ObjectGraphType<Submission>
    {
        public SubmissionType(ApplicationContext applicationContext)
        {
            Name = "Submission";
            Description = "A submission from a client for an item fulfillment.";
            Field(x => x.Id).Description("The Id of the Submission.");
            Field(x => x.ClientSubmissionId).Description("The unique id the client passed for a Submission.");
            Field(x => x.DateTime).Description("The date time of the Submission.");
            Field(x => x.FirstName).Description("The first name of the Submission.");
            Field(x => x.LastName).Description("The last name of the Submission.");
            Field(x => x.Address1).Description("The address line 1 of the Submission.");
            Field(x => x.Address2).Description("The address line 2 of the Submission.");
            Field(x => x.City).Description("The city of the Submission.");
            Field(x => x.State).Description("The state of the Submission.");
            Field(x => x.PostalCode).Description("The postal code of the Submission.");
            Field(x => x.CountryCode).Description("The postal code of the Submission.");
            Field(x => x.Email).Description("The email of the Submission.");
            Field(x => x.Phone).Description("The phone number of the Submission.");
            Field(x => x.Status).Description("The phone number of the Submission.");
            
            Field<ListGraphType<ItemOrderType>>()
                .Name("ItemOrders")
                .Description("The Item Orders")
                .Resolve((context) =>
                {
                    return applicationContext.ItemOrder.Where(x => x.SubmissionId == context.Source.Id);
                });
        }
    }
}

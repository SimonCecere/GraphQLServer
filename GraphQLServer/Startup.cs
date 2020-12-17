using GraphQL.Types;
using GraphQLServer.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphQL;
using GraphQLServer.Schema.Types;
using GraphQLServer.Schema;
using GraphQLServer.Schema.InputTypes;
using GraphQL.Execution;
using Microsoft.Extensions.Options;
using GraphQL.SystemTextJson;

namespace GraphQLServer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            WebHostEnvironment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddSingleton<IErrorInfoProvider>(services =>
            {
                return new ErrorInfoProvider(new ErrorInfoProviderOptions { ExposeExceptionStackTrace = false });
            });

            //Types
            services.AddSingleton<SubmissionType>();
            services.AddSingleton<ItemOrderType>();
            services.AddSingleton<ProductType>();

            //Input Types
            services.AddSingleton<SubmissionInputType>();
            services.AddSingleton<ItemOrderInputType>();

            //Schema
            services.AddSingleton<RootQuery>();
            services.AddSingleton<Mutation>();
            services.AddScoped<ISchema, SubmissionSchema>();

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:ApplicationDatabase"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationContext applicationContext)
        {

            //if (env.IsEnvironment("Local"))
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            applicationContext.Database.Migrate();

            app.UseRouting();
            
            if (!env.IsProduction())
            {
                app.UseGraphQLVoyager(); //Interesting map view.
                app.UseGraphQLPlayground(); //Simple and clean design 
                app.UseGraphQLAltair(); //Smooth UI
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

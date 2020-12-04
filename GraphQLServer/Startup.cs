using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using GraphQLServer.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphQL;
using GraphQLServer.Types;

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
            services.AddSingleton<SubmissionType>();
            services.AddSingleton<ItemOrderType>();
            services.AddSingleton<ProductType>();
            services.AddSingleton<RootQuery>();
            services.AddScoped<ISchema, SubmissionSchema>();

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:ApplicationDatabase"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationContext applicationContext)
        {

            if (env.IsEnvironment("Local"))
            {
                app.UseDeveloperExceptionPage();
            }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using IdentityHostSvr.Models;
using System.Reflection;
using System.IO;
using Swashbuckle.AspNetCore.Swagger;

namespace IdentityHostSvr
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IIdentityServerBuilder  IdentityBuilder { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            IdentityBuilder = services.AddIdentityServer()
               .AddInMemoryIdentityResources(IdentityResourcesConfig.GetIdentityResources())
               .AddInMemoryApiResources(ApiResourcesConfig .GetApis())
               .AddInMemoryPersistedGrants()
               .AddInMemoryClients(ClientsConfig.GetClients())
               .AddTestUsers(UsersConfig.GetUsers())
               .AddDeveloperSigningCredential();



            services.AddSwaggerGen(c =>

            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Identity Token server Api",
                    Description = "Playground IdentityServer4",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Marc koutzarov",
                        Email = string.Empty,
                        Url = "https://www.linkedin.com/in/marckoutzarov/"
                    },
                    License = new License
                    {
                        Name = "Use, steal or improve :-)",
                        Url = "https://www.linkedin.com/in/marckoutzarov/"
                    }
                });


                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
               
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseMvc();

            app.UseIdentityServer();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity Token server Api");
            });
        }
    }
}

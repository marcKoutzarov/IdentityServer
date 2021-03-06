﻿using IdentitySvr.Interfaces.Repositories;
using IdentitySvr.Interfaces.Stores;
using IdentitySvr.Repositories;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using IdentitySvr.Host.Stores;
using IdentitySvr.Host.Validators;
using IdentitySvr.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace IdentitySvr.Host
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
           
            //Inject the Repository classes
            services.AddTransient<IResourcesRepo, ResourceRepo>();
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<IGrantsRepo, GrantsRepo>();

            //Inject the classes for the profile service
            services.AddTransient<IUserStore, UserStore>();
            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            services.AddTransient<IProfileService, ProfileService>();

            // set up Identityserver
            IdentityBuilder = services.AddIdentityServer()
               .AddResourceStore<ResourceStore>()
               .AddClientStore<ClientStore>()
               .AddPersistedGrantStore<PersistedGrantsStore>()
               .AddProfileService<ProfileService>()
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

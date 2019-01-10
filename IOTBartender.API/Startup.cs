using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using IOTBartender.API.Background;
using IOTBartender.Application.Commands;
using IOTBartender.Domain.Entititeis;
using IOTBartender.Domain.UnitOfWorks;
using IOTBartender.Domain.UnitOfWorks.Repositories;
using IOTBartender.Infrastructure.EFCore;
using IOTBartender.Infrastructure.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IOTBartender.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => {
                    options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            // Add in memory efcore to the project.
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();

            // Add incoming and outgoing data services as background jobs.
            services.AddHostedService<ScopedHostedService>();

            // Add MediatR.
            services.AddMediatR(typeof(Command));

            // Add AutoMapper.
            services.AddAutoMapper();

            //using (var scope = services.BuildServiceProvider().CreateScope())
            //{
            //    // Get unit of work.
            //    var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            //    var fluid1 = unitOfWork.Repository.Add(new Fluid() { Name = "Vodka" });
            //    var fluid2 = unitOfWork.Repository.Add(new Fluid() { Name = "Rom" });
            //    var fluid3 = unitOfWork.Repository.Add(new Fluid() { Name = "Gin" });
            //    var fluid4 = unitOfWork.Repository.Add(new Fluid() { Name = "Cola" });

            //    var recipeOne = unitOfWork.Repository.Add(new Recipe()
            //    {
            //        Name = "Recipe One",
            //        Components = new List<Component>()
            //        {
            //            new Component() { FluidId = fluid1.Id, Size = 1},
            //            new Component() { FluidId = fluid2.Id, Size = 1},
            //        }
            //    });

            //    unitOfWork.Repository.Add(new Order() { RecipeId = recipeOne.Id, Events = new List<OrderEvent>() { new OrderEvent() { Time = DateTime.UtcNow, Type = OrderEvent.OrderEventType.Submitted } } });

            //    var result = unitOfWork.SaveChanges().Result;
            //}
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
                app.UseHsts();
            }

            // Enable Cross origin request for everybody ONLY FOR DEVELOPMENT.
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

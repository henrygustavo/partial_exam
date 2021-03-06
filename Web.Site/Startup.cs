﻿namespace Web.Site
{
    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Common.Api.Middleware;
    using Common.Infrastructure.Persistence;
    using Common.Infrastructure.Persistence.NHibernate;
    using Swashbuckle.AspNetCore.Swagger;
    using System;
    using Product.Domain.Repository;
    using Product.Infrastructure.Persistence.NHibernate.Repository;
    using Product.Application.Service;
    using Product.Application.Assembler;
    using Web.Site.User.Application.Service;
    using Web.Site.User.Infrastructure.Persistence.NHibernate.Repository;
    using Web.Site.User.Domain.Repository;
    using Web.Site.User.Application.Assembler;

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
            services.AddAutoMapper();
            services.AddMvc();
            services.AddSingleton(new SessionFactory(Environment.GetEnvironmentVariable("MYSQL_CONECTION_STRING_LOCAL")));
            var serviceProvider = services.BuildServiceProvider();
            var mapper = serviceProvider.GetService<IMapper>();

            services.AddSingleton(new ProductCreateAssembler(mapper));
            services.AddSingleton(new CategoryCreateAssembler(mapper));
            services.AddSingleton(new UserCreateAssembler(mapper));

            services.AddScoped<IUnitOfWork, UnitOfWorkNHibernate>();

            services.AddTransient<IProductRepository, ProductNHibernateRepository>((ctx) =>
            {
                IUnitOfWork unitOfWork = ctx.GetService<IUnitOfWork>();
                return new ProductNHibernateRepository((UnitOfWorkNHibernate)unitOfWork);
            });

            services.AddTransient<ICategoryRepository, CategoryNHibernateRepository>((ctx) =>
            {
                IUnitOfWork unitOfWork = ctx.GetService<IUnitOfWork>();
                return new CategoryNHibernateRepository((UnitOfWorkNHibernate)unitOfWork);
            });

            services.AddTransient<IUserRepository, UserNHibernateRepository>((ctx) =>
            {
                IUnitOfWork unitOfWork = ctx.GetService<IUnitOfWork>();
                return new UserNHibernateRepository((UnitOfWorkNHibernate)unitOfWork);
            });

            services.AddTransient<IRoleRepository, RoleNHibernateRepository>((ctx) =>
            {
                IUnitOfWork unitOfWork = ctx.GetService<IUnitOfWork>();
                return new RoleNHibernateRepository((UnitOfWorkNHibernate)unitOfWork);
            });

            services.AddTransient<IUserAplicationService, UserAplicationService>();
            services.AddTransient<IProductApplicationService, ProductApplicationService>();
            services.AddTransient<ICategoryApplicationService, CategoryApplicationService>();

            services.AddSingleton<IAmqpApplicationService, AmqpApplicationService>(
                ctx => new AmqpApplicationService(Environment.GetEnvironmentVariable("DCS_RABBITMQ_URL"))
             );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "System API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");

            app.UseMiddleware(typeof(ErrorMiddleware))
                .UseMvc()
               .UseDefaultFiles(options)
               .UseStaticFiles()
                .UseSwagger()
               .UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Space.Card.Game.WebApi.Infrastructure;
using Space.Card.Game.WebApi.Dtos;
using Space.Card.Game.WebApi.Handlers.Base;
using Space.Card.Game.WebApi.Handlers.Commands;
using Space.Card.Game.WebApi.Handlers.Queires;
using Space.Card.Game.WebApi.Interfaces;
using Space.Card.Game.WebApi.Interfaces.Base;
using Space.Card.Game.WebApi.Interfaces.Commands;
using Space.Card.Game.WebApi.Interfaces.Queries;

namespace Space.Card.Game.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public Startup() { }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterDependencies(services);

            services.AddDbContext<ApiContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(AutoMapperProfile));
           //services.addau

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterDependencies(IServiceCollection services)
        {

            services.AddScoped<IHandlerBase<BattleCommandResponseDto>,
                BattleCommandHandler<BattleCommandResponseDto>>();

            services.AddScoped<IHandlerExecutor<BattleCommandResponseDto>,
                HandlerExecutor<BattleCommandResponseDto>>();


        }
    }
}

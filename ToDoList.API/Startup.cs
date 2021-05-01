using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDoList.API.CustomMiddleware;
using ToDoList.BusinessLayer.Abstract;
using ToDoList.BusinessLayer.Concrete;
using ToDoList.DataAccessLayer.Abstract;
using ToDoList.DataAccessLayer.Concrete;
using ToDoList.DataAccessLayer.ToDoContext;

namespace ToDoList.API
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
            services.AddControllers();

            services.AddDbContext<ToDoDbContext>(opt => opt.UseSqlite
                (Configuration.GetConnectionString("DefaultConnection"), y => y.MigrationsAssembly("ToDoList.DataAccessLayer")));

            services.AddScoped<IToDoRepository, ToDoRepository>();
            services.AddScoped<IToDoService, ToDoService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("CoreSwagger", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Swagger on ASP.NET Core",
                    Version = "1.0.0",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Name = "Musa Ağaçyetiştiren",
                    },
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionMiddleware();

            app.UseSwagger()
            .UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/CoreSwagger/swagger.json", "Swagger Test .Net Core");
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

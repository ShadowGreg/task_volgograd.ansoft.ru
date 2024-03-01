using EntityFramework.Firebird;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.EntityFrameworkCore;
using task_volgograd.ansoft.ru.dataAccess;
using task_volgograd.ansoft.ru.dataAccess.Repositories;
using task_volgograd.ansoft.ru.domain.Abstractions.Repositories;

namespace task_volgograd.ansoft.ru
{
    public class Startup(IConfiguration configuration)
    {
        public IConfiguration Configuration { get; } = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            System.Data.Common.DbProviderFactories.RegisterFactory(
                FbProviderServices.ProviderInvariantName,
                FirebirdClientFactory.Instance
            );

            services.AddCors();
            services.AddControllers().AddMvcOptions(x =>
                x.SuppressAsyncSuffixInActionNames = false);
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddDbContext<DataContext>(options =>
                {
                    options.UseFirebird(Configuration.GetConnectionString("ServiceDb"));
                    // options.UseSnakeCaseNamingConvention();
                    // options.UseLazyLoadingProxies();
                });

            services.AddOpenApiDocument(options =>
                {
                    options.Title = "Message sender API Doc";
                    options.Version = "1.0";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseOpenApi();
            app.UseSwaggerUi(x =>
                {
                    x.DocExpansion = "list";
                });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
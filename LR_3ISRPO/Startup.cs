using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using LR_3ISRPO.Models;


namespace LR_3ISRPO
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RestouranContext>(options => options.UseSqlServer(SqlConnectionIntegratedSecurity));
            services.AddControllers();
        }

        public static string SqlConnectionIntegratedSecurity
        {
            get
            {
                var sb = new SqlConnectionStringBuilder
                {
                    DataSource = "(localdb)\\MSSQLLocalDB",
                    IntegratedSecurity = true,
                    InitialCatalog = "RESTOURAN"
                };
                return sb.ConnectionString;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}

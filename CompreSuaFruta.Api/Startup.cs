using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompreSuaFruta.Api.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CompreSuaFruta.Business.Concrete;
using CompreSuaFruta.Business.Interface;
using CompreSuaFruta.Dal.Concrete;
using CompreSuaFruta.Dal.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CompreSuaFruta.Dal;
using CompreSuaFruta.Dal.Context.Contexts;

namespace CompreSuaFruta.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _dalHelper = new DalHelper();
            _dalHelper.CriarBancoSQLite();
        }

        public IConfiguration Configuration { get; }
        private readonly DalHelper _dalHelper;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            
            services.AddDbContext<ProdutoDbContext>(o =>
                    o.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<StatusVendaDbContext>(o =>
                    o.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<UsuarioDbContext>(o =>
                    o.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<VendaDbContext>(o =>
                    o.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ProdutoVendaDbContext>(o =>
                    o.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IProdutoVendaDal, ProdutoVendaDal>();
            services.AddScoped<IProdutoDal, ProdutoDal>();
            services.AddScoped<IUsuarioDal, UsuarioDal>();
            services.AddScoped<IVendaDal, VendaDal>();
            services.AddScoped<IProdutoBll, ProdutoBll>();
            services.AddScoped<IProdutoVendaBll, ProdutoVendaBll>();
            services.AddScoped<IUsuarioBll, UsuarioBll>();
            services.AddScoped<IVendaBll, VendaBll>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

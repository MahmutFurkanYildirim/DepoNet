using DepoNet.Business.Interfaces;
using DepoNet.Business.Services;
using DepoNet.Data.Context;
using DepoNet.Data.Repositories;
using DepoNet.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace DepoNet
{
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; } = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            // Veritabanı bağlantısı — LocalDB, kurulum gerektirmez
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=DepoNetDb;Trusted_Connection=True;"                    
                ));

            // Repositories
            services.AddScoped<IUrunRepository, UrunRepository>();
            services.AddScoped<IBOMRepository, BOMRepository>();
            services.AddScoped<IDepoRepository, DepoRepository>();
            services.AddScoped<IStokRepository, StokRepository>();
            services.AddScoped<ISiparisRepository, SiparisRepository>();

            // Services
            services.AddScoped<IUrunService, UrunService>();
            services.AddScoped<IBOMService, BOMService>();
            services.AddScoped<IDepoService, DepoService>();
            services.AddScoped<IStokService, StokService>();
            services.AddScoped<ISiparisService, SiparisService>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
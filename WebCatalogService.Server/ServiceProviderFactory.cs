using WebCatalogService.Server.Repositories;
using Microsoft.Extensions.DependencyInjection;
using WebCatalogService.Server.Interfaces;
namespace WebCatalogService.Server
{
    public class ServiceProviderFactory
    {
        public ServiceProvider Create()
        {
            var services = new ServiceCollection();
            services.AddTransient<IProductsService, ProductsRepository>();

            //services.AddTransient<XmlManager>();
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}

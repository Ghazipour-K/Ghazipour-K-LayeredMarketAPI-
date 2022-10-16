using System.Web.Http;
using Unity;
using Unity.WebApi;
using Market.Repository;

namespace Market
{
    public static class UnityConfig
    {
        public static UnityContainer container = new UnityContainer();

        public static void RegisterComponents()
        {

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IAdminRepository, AdminRepository>();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<IGenericRepository<ProductTable>, GenericRepository<ProductTable>>();
            container.RegisterType<IGenericRepository<DistributionScheduleTable>, GenericRepository<DistributionScheduleTable>>();
            container.RegisterType<IGenericRepository<ShoppingCardTable>, GenericRepository<ShoppingCardTable>>();
            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
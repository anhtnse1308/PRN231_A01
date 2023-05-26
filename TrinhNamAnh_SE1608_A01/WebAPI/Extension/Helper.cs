using BussinessObject.Models;

namespace WebAPI.Extension
{
    public static class Helper
    {
        public static Customer ImportJson()
        {
            var jsonData = new ConfigurationBuilder().AddJsonFile(@"appsettings.json");
            IConfiguration config = jsonData.Build();

            var jsonAdmin = config.GetSection("AdminAccount").Get<Customer>();
            return (Customer)jsonAdmin;
        }
    }
}

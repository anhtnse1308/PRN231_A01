using BussinessObject.Models;

namespace Client.Extension
{
    public static class Helper
    {
        public static string baseUrl = "http://localhost:8081/api/";
        public static Customer ImportJson()
        {
            var jsonData = new ConfigurationBuilder().AddJsonFile(@"appsettings.json");
            IConfiguration config = jsonData.Build();

            var jsonAdmin = config.GetSection("AdminAccount").Get<Customer>();
            return (Customer)jsonAdmin;
        }
    }
}

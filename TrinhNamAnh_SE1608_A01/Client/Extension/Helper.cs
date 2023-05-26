using BussinessObject.Models;
using System.Security.Principal;
using System.Text.Json;

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
        public static void Set<T>(this ISession session, string key, T? value)
        {
            JsonSerializerOptions option = new JsonSerializerOptions();
            option.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            string json = JsonSerializer.Serialize(value, option);
            session.SetString(key, json);
        }

        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            if (value == null)
            {
                return default;
            }
            else
            {
                var result = JsonSerializer.Deserialize<T>(value);
                return result;
            }
        }
        public static Customer? GetLoginUser(this ISession session)
        {
            var value = session.GetString("login-user");
            if (value != null)
            {
                return JsonSerializer.Deserialize<Customer>(value);
            }
            else
            {
                return null;
            }
        }
    }
}

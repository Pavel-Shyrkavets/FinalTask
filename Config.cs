using Microsoft.Extensions.Configuration;

namespace FinalTask
{
    public static class Config
    {
        private static IConfigurationRoot GetBuilder()
        {
            var configurationBuilder = new ConfigurationBuilder();

            configurationBuilder.AddInMemoryCollection(
                    new Dictionary<string, string?>
                    {
                        ["credentials"] = "Automation",
                        ["index_page_url"] = "https://www.saucedemo.com/",
                        ["inventory_page_url"] = "https://www.saucedemo.com/inventory.html",
                    });

            var config = configurationBuilder.Build();

            return config;
        }
        public static string GetConfigValue(string key)
        {
            return GetBuilder()[key] ?? "value";
        }
    }
}

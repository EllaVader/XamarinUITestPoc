using System.Configuration;

namespace MobileFramework.Config
{
    public class TestConfiguration : ConfigurationSection
    {
        public static TestConfiguration Configuration => (TestConfiguration)ConfigurationManager.GetSection("TestConfiguration");

        [ConfigurationProperty("TestSettings")]
        public TestFrameworkElementCollection TestSettings => (TestFrameworkElementCollection)base["TestSettings"];
    }
}

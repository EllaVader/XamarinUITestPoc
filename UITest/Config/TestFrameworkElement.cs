using System.Configuration;

namespace MobileFramework.Config
{
    public class TestFrameworkElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name => (string)base["name"];

        [ConfigurationProperty("environment", IsRequired = true)]
        public string Environment => (string)base["environment"];

        [ConfigurationProperty("pkgpath", IsRequired = true)]
        public string PackagePath => (string)base["pkgpath"];

        [ConfigurationProperty("pkgname", IsRequired = true)]
        public string PackageName => (string)base["pkgname"];

        [ConfigurationProperty("platform", IsRequired = true)]
        public string Platform => (string)base["platform"];
    }
}

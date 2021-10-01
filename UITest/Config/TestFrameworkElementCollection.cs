using System.Configuration;

namespace MobileFramework.Config
{
    [ConfigurationCollection(typeof(TestFrameworkElement), AddItemName = "TestSetting", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class TestFrameworkElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new TestFrameworkElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as TestFrameworkElement).Name;
        }

        public new TestFrameworkElement this[string type] => (TestFrameworkElement)BaseGet(type);
    }
}

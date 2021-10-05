using Xamarin.UITest;

namespace MobileFramework.Models
{
    public class AppDetail
    {
        public string AppPath { get; set; }
        public string PackageName { get; set; }
        public string Environment { get; set; }
        public Platform Platform { get; set; }
    }
}

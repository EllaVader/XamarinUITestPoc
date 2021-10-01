using System;
using Xamarin.UITest;

namespace MobileFramework.Config
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (Settings.Platform == Platform.Android)
            {
                var path = Settings.PackagePath + Settings.PackageName;//@"C:\Users\JanineRoe\source\repos\JanineTestApp\JanineTestApp\JanineTestApp.Android\bin\Release\com.companyname.janinetestapp.apk";
                return ConfigureApp.Android.ApkFile(path).StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }

        public static void InitializeSettings(string target)
        {
            Settings.Name = TestConfiguration.Configuration.TestSettings[target].Name;
            Settings.Platform = (Platform)Enum.Parse(typeof(Platform), TestConfiguration.Configuration.TestSettings[target].Platform);
            Settings.PackagePath = TestConfiguration.Configuration.TestSettings[target].PackagePath;
            Settings.PackageName = TestConfiguration.Configuration.TestSettings[target].PackageName;
            Settings.Environment = TestConfiguration.Configuration.TestSettings[target].Environment;
        }
    }
}
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
            else
            {
               //var path = "/Users/janine/code/XamarinUITestPoc/JanineTestApp/JanineTestApp.iOS/bin/iPhoneSimulator/Debug/device-builds/iphone se (2nd generation)-15.0/JanineTestApp.iOS.app";
                return ConfigureApp.iOS
                    .Debug()
                    //.AppBundle(path)
                    .InstalledApp("com.companyname.JanineTestApp")
                    // .DeviceIdentifier("DB9CD45A-A511-4623-A8FE-330DB8B62A6A")
                    .StartApp();
            }

        }

        public static void InitializeSettings(string target)
        {
            //var target = "Dev-iOS";
            Settings.Name = TestConfiguration.Configuration.TestSettings[target].Name;
            Settings.Platform = (Platform)Enum.Parse(typeof(Platform), TestConfiguration.Configuration.TestSettings[target].Platform); //Platform.iOS;
            Settings.PackagePath = TestConfiguration.Configuration.TestSettings[target].PackagePath; //"/Users/janine/code/XamarinUITestPoc/JanineTestApp/JanineTestApp.iOS/bin/iPhoneSimulator/Debug/";
            Settings.PackageName = TestConfiguration.Configuration.TestSettings[target].PackageName;
            Settings.Environment = "";//TestConfiguration.Configuration.TestSettings[target].Environment;
        }
    }
}
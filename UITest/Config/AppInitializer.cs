using Microsoft.Extensions.Configuration;
using MobileFramework.Models;
using NUnit.Framework;
using System;
using Xamarin.UITest;

namespace MobileFramework.Config
{
    public class AppInitializer
    {
        public static AppDetail AppDetails { get; set; }
        public static IApp StartApp()
        {
            if (AppDetails.Platform == Platform.Android)
            {
                var path = AppDetails.AppPath + AppDetails.PackageName;//@"C:\Users\JanineRoe\source\repos\JanineTestApp\JanineTestApp\JanineTestApp.Android\bin\Release\com.companyname.janinetestapp.apk";
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
            IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
            TestContext.Out.WriteLine($"Inside IntializeSettings - Target is: {target}");
            AppDetails = config.GetSection(target).Get<AppDetail>();
            TestContext.Out.WriteLine($"AppDetails is {AppDetails.AppPath}");

        }
    }
}
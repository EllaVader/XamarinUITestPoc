using BoDi;
using MobileFramework.Config;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace MobileFramework.Hooks
{
    [Binding]
    public class UITestAppSetup
    {
        private IApp _app;
        private IObjectContainer _container;


        public UITestAppSetup(IObjectContainer container)
        {
            // this is needed to register the IApp Instance that will be shared across steps
            _container = container;

        }

        [BeforeScenario]
        public void SetupFeature()
        {
            var appCenterTest = Environment.GetEnvironmentVariable("APP_CENTER_TEST");
            Console.WriteLine($"APP_CENTER_TEST is: {appCenterTest}");
            TestContext.Out.WriteLine($"APP_CENTER_TEST is: {appCenterTest}");
            string target = TestContext.Parameters.Get("target");
            TestContext.Out.WriteLine($"Target is: {target}");
            Console.WriteLine($"Target is: {target}");

            if (string.IsNullOrEmpty(appCenterTest))
            {
                TestContext.Out.WriteLine("Running test locally");
                Console.WriteLine("Running test locally");
                AppInitializer.InitializeSettings(target);
                _app = AppInitializer.StartApp();
            }
            else
            {
                TestContext.Out.WriteLine("Running test in App Center");
                Console.WriteLine("Running test in App Center");
                //string blah = TestContext.Parameters.Get("TARGET");
                //TestContext.Out.WriteLine($"TestContext target is: {blah}");
                //Console.WriteLine($"TestContext target is: {blah}");
                //string anotherTarget = Environment.GetEnvironmentVariable("TARGET");
                //TestContext.Out.WriteLine($"anotherTarget is: {anotherTarget}");
                //Console.WriteLine($"anotherTarget is: {anotherTarget}");
                //AppInitializer.InitializeSettings(anotherTarget);
                _app = ConfigureApp.Android.StartApp();//AppInitializer.StartApp();
            }

            // set the IApp instance now - use this in step classes via Dependency Injection
            _container.RegisterInstanceAs(_app);

            //_app.Repl();

        }

    }
}

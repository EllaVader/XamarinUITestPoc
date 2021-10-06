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

            if (string.IsNullOrEmpty(appCenterTest))
            {
                TestContext.Out.WriteLine("Running test locally");

                string target = TestContext.Parameters.Get("target");
                AppInitializer.InitializeSettings(target);
                _app = AppInitializer.StartApp();
            }
            else
            {
                TestContext.Out.WriteLine("Running test in App Center");
                _app = ConfigureApp.Android.StartApp();//AppInitializer.StartApp();
            }

            // set the IApp instance now - use this in step classes via Dependency Injection
            _container.RegisterInstanceAs(_app);

            //_app.Repl();

        }

    }
}

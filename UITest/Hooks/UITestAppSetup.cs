using BoDi;
using MobileFramework.Config;
using NUnit.Framework;
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
            string target = TestContext.Parameters.Get("target");
            AppInitializer.InitializeSettings(target);
            _app = AppInitializer.StartApp(Settings.Platform);
            // set the IApp instance now - use this in step classes via Dependency Injection
            _container.RegisterInstanceAs(_app);

            _app.Repl();

        }

    }
}

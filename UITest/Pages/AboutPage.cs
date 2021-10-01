using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace MobileFramework.Pages
{
    public class AboutPage : BasePage
    {
        public Query LearnMoreButton = x => x.Marked("Learn more");
        public AboutPage(IApp app) : base(app) { }

        public bool IsAboutPageDisplayed()
        {
            var button = AppContext.Query(LearnMoreButton);
            return button.Length > 0;
        }

    }
}

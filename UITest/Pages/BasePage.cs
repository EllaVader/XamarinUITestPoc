using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace MobileFramework.Pages
{
    public class BasePage
    {

        protected IApp AppContext;

        protected Query BrowseButton = x => x.Marked("Browse");
        protected Query AboutButton = x => x.Marked("About");

        public BasePage(IApp app)
        {
            AppContext = app;
        }

        public BrowseListPage NavigateToBrowsePage()
        {
            AppContext.Tap(BrowseButton);
            BrowseListPage browseListPage = new BrowseListPage(AppContext);
            AppContext.WaitForElement(browseListPage.AddItemButton);
            return browseListPage;
        }

        public AboutPage NavigateToAboutPage()
        {
            AppContext.Tap(AboutButton);
            AboutPage aboutPage = new AboutPage(AppContext);
            AppContext.WaitForElement(aboutPage.LearnMoreButton);
            return aboutPage;
        }

    }
}

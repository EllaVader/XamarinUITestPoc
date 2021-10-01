using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace MobileFramework.Pages
{
    public class AddListItemPage : BasePage
    {

        public Query TextInput = x => x.Marked("automation.text");
        public Query DescriptionInput = x => x.Marked("automation.description");
        public Query SaveButton = x => x.Marked("Save");

        public AddListItemPage(IApp app) : base(app) { }

        public BrowseListPage AddNewItem(string text, string description)
        {
            AppContext.EnterText(TextInput, text);
            AppContext.EnterText(DescriptionInput, description);
            AppContext.Tap(SaveButton);

            BrowseListPage listPage = new BrowseListPage(AppContext);
            AppContext.WaitForElement(listPage.AddItemButton);
            return listPage;
        }

    }
}

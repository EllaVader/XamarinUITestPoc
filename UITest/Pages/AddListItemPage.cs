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
           // AppContext.Tap(TextInput);
            AppContext.EnterText(TextInput, text);
           // AppContext.Tap(DescriptionInput);
            AppContext.EnterText(DescriptionInput, description);
           // AppContext.DismissKeyboard();
            AppContext.Tap(SaveButton);

            BrowseListPage listPage = new BrowseListPage(AppContext);
            AppContext.WaitForElement(listPage.AddItemButton);
            return listPage;
        }

    }
}

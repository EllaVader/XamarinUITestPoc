using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace MobileFramework.Pages
{
    public class BrowseListPage : BasePage
    {

        public Query AddItemButton => x => x.Marked("Add");
        public Query ListItemValue(string item) => x => x.Marked("list-items").Descendant("LabelRenderer").All().Text(item);

        public BrowseListPage(IApp app) : base(app) { }

        public AddListItemPage ClickAdd()
        {
            AppContext.Tap(AddItemButton);
            AddListItemPage addItemPage = new AddListItemPage(AppContext);
            AppContext.WaitForElement(addItemPage.TextInput);
            return addItemPage;
        }

        public bool IsListItemDisplayed(string item)
        {
            var result = AppContext.Query(ListItemValue(item));
            return result.Length == 1;
        }

    }
}

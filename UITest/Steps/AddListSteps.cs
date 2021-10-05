﻿using MobileFramework.Models;
using MobileFramework.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xamarin.UITest;

namespace MobileFramework.Steps
{
    [Binding]
    public class AddListSteps
    {
        private IApp _app;
        private BasePage _basePage => new BasePage(_app);
        private BrowseListPage _browseListPage;
        private AddListItemPage _addListItemPage;
        private ScenarioContext _scenarioContext;


        public AddListSteps(IApp app, ScenarioContext scenarioContext)
        {
            _app = app;
            _scenarioContext = scenarioContext;

        }

        [Given(@"I am on the Browse Page")]
        public void GivenIAmOnTheBrowsePage()
        {
            _browseListPage = _basePage.NavigateToNotesListPage();
        }

        [When(@"I click the add")]
        public void WhenIClickAdd()
        {
            _addListItemPage = _browseListPage.ClickAdd();
        }

        [When(@"I enter the list details as")]
        public void WhenIEnterTheListDetailsAs(Table table)
        {
            Note note = table.CreateInstance<Note>();
            _scenarioContext.Add("title", note.Title);
            _scenarioContext.Add("description", note.Description);
            _browseListPage = _addListItemPage.AddNewItem(note.Title, note.Description);
        }


        [Then(@"I should see the new item is added in the list")]
        public void ThenIShouldSeeTheNewItemIsAddedInTheList()
        {
            // verify that the item was added and is listed on the browse items page
            Assert.That(_browseListPage.IsListItemDisplayed(_scenarioContext.Get<string>("title")), Is.True);
            Assert.That(_browseListPage.IsListItemDisplayed(_scenarioContext.Get<string>("description")), Is.True);
        }

    }
}

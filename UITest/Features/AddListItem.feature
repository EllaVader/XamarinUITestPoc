Feature: AddListItem
	Add list feature to test how it works

@positive
Scenario: Add new list item
	Given I am on the Browse Page
	When I click the add
	And I enter the list details as 
	| title | description      |
	| Demo  | Demo description |
	Then I should see the new item is added in the list
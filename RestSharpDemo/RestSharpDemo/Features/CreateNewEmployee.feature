Feature: CreateNewEmployee

@api
Scenario: Create a new employee
	Given Create Request "create" with "POST" method
	When I Create a request body with the following values
	| name  | salary | age |
	| MAemp | 123456 | 28  |
	And Add the serialized body to the API request
	And Execute API
	Then returned status code will be "200"
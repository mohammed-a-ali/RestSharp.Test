Feature: GetSingleEmployeeContent

@api
Scenario: Check Get Single employee Content
	Given Create Request "employee/{id}" with "GET" method
	When Create URL segment for "id" with parameter "8235"
	And Execute API
	And Deserialize the employee api content
	Then The employee should have the following values
|Key				|Value				|
| id				| 8235				|
| employee_name		| Stewart Hamilton	|
| employee_salary	| 67162				|
| employee_age		| 26				|
| profile_image		|					|


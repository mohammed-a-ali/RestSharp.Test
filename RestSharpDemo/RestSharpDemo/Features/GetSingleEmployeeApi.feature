Feature: GetSingleEmployeeApi

@api
Scenario: Check Single employee status
	Given Create Request "employee/{id}" with "GET" method
	When Create URL segment for "id" with parameter "7337"
	And Execute API
	Then returned status code will be "200"

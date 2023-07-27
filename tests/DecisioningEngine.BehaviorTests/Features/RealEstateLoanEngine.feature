Feature: Credit Application should be able to be decisioned 

Real estate loan application is submitted and decisioned with valid status

@tag1
Scenario: Credit Application can be decisioned
	Given Credit Application is submitted 
	When Credit Application is decisioned
	Then decision is to approve

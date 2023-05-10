## Guideline Rules for TDD

### Defininitions of TDD
Container: C# class that is tasked to do the work
Component: Object inside the Container that Container 
	is relying upon to do some or all of work
Test class: Unit test class responsible for unit testing the Container class
Test method: Unit test class method responsible for testing a method of the Containter class

### TDD Coding Rules
1. Container should not instantiate its components
2. Components should be injected into Container 
	via constructor
3. Component should be injected 
	using Interface rather than Concrete class type

### Unit Test Rules
1. One test class per Container class
2. Test class should have the Container class object that is being tested as Test class member variable (do not instatiate in test methods)
3. Test methods should test the methods of Container class methods without consideration for Component methods!!!
	a. If Container class has components, these components should be Mocked in Test Class using some Mocking framework, normally Moq from Nuget
	b. Test method name should describe the Container class method that is tested and the scenario
# EpamLearnTask

## Task
Automate test cases from the previous home task using identified elements and its locators. For this practical task, Selenium WebDriver and any preferred unit test framework (NUnit, MSTest or xUnit) should be used. The type of .NET project is Class Library.


The following basic WebDriver features should be used:
browser interactions.
capabilities and features browser specifics.
explicit and implicit waits.


Enlarge the window. Use basic commands that can be executed on an element (at least click, send keys, clear). 


P.S: Make all tests parameterized to practice the Data-Driven approach. 

## Test Cases
### Test case #1. Validate that the user can search for a position based on criteria.

Navigate to https://www.epam.com/

Find a link “Carriers” and click on it

Write the name of any programming language in the field “Keywords” (should be taken from test parameter)

Select “All Locations” in the “Location” field (should be taken from the test parameter)

Select the option “Remote”

Click on the button “Find”

Find the latest element in the list of results

Click on the button “View and apply”

Validate that the programming language mentioned in the step above is on a page

### Test case #2. Validate global search works as expected.

Navigate to https://www.epam.com/

Find a magnifier icon and click on it

Find a search string and put there “BLOCKCHAIN”/”Cloud”/”Automation” (use as a parameter for a test)

Click “Find” button

Validate that all links in a list contain the word “BLOCKCHAIN”/”Cloud”/”Automation” in the text. LINQ should be used. 




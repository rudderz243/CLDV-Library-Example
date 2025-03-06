# LibraryManager EF Example
## Instructions
1) Add a switch-case or if-else style menu system to the main application (Create, Read, Update, Delete, Exit)
2) Using the Create method I gave you, do additional research and attempt to create Read, Update, and Delete methods

## Hints
1) When getting all the books for the Read method, you will get the books in a list format. Use a loop to go through the list and print out all the options.
2) For the Update and Delete methods, ensure that your code only affects the book you want to change, not all of them
3) Make sure to call .SaveChanges() and .Close(), otherwise your changes will not show up in SSMS / the Read method!
4) In this example, the class Book would be considered a "Model" in the MVC architecture. Our menu with the different methods would represent the methods in a "Controller", and the interface is the "View".
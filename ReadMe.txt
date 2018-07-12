Project CSVParserLib - a shared class project to handle csv file parsing
	*Parser.cs - static class for parsing and validation of csv file contents
	*Utilized existing parsers from Microsoft.VisualBasic.FileIO

Project CSVParser - a console solution for displaying CSV file contents

Project LACERAMVC - an MVC application
	*NinjectResolver.cs - kernel bindings
	*NinjectWebCommon.cs - registers services
	*_Layout.cshtml - page header/footer
	*Home/Index.cshtml - home page with file upload ability
	*Employee/Index.cshtml - employee listing from database
	*App_Data/dbEmployees.mdf - the local database file
	*Controllers/EmployeeController - handles returning employee entities from the db to the view
	*Controllers/HomeController - handles uploading the CSV file and uploading to the db

Project Ninject.Concrete - a class project for handling db operations against the Employee table

Project Ninject.Interface - a class project for defining interface method signatures

Project Ninject.Model - a class project for defining the Employee model

Project UnitTestCSVParserLib - a test project for unit testing of the parser lib


Improvements:

TODO:  rework home/index page to be "pretty" using css
TODO:  rework employee/index page to be "pretty" using css
TODO:  create a SharedData class project to hold the database files
TODO:  use a model-first approach to generate the database table Employees
TODO:  create repositories for the entities (possibly use EntityFramework)


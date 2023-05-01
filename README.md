# PetStore
Petstore Application

A simple web application to manage the details of someone's pets


Uses the following technology:
- ASP.NET MVC
- EFCore
- Serilog

Solution structure
- PetStore solution
- PetStore.Web web application
- PetStore.Services service layer including EF integration

Hosted
- Azure SQL Database
- Azure Web Application
- Create a pipeline to build the project in Azure DevOps, connect to repository in GitHub

Details
- Use Serilog for logging. Dependency Injection in program.cs
- Database functionality in Petstore Services Project. Connection in appsettings.json. Dependency Injection in program.cs

Interface
- List pets,
- List pets with the following data: ID, Name, Type (bird, lizard, cat, dog, rabbit, ferret), Date of birth, Weight
- Provide functionality to filter the listed pets by animal type
- Order the results by pet name
- utton to Edit a record
- Button to Delete a record. With confirmation JavaScript popup (“Are you sure you want to delete this pet? Yes/no”)
- Confirmation of deletion message once executed
- Log the action and record ID
- Link to Add a new Pet page
- Edit pet page to be able to edit all of the details of the pet:
- Validation on name, type, date of birth, weight
- Make sure that no two pets in the database have the same name and date of birth
- Save Button
- Log the action and a JSON version of the modified data to the log text file
- Save
- Redirect to list with confirmation message on list page after saving
- Cancel Button (links to list pets page)
- Add Pet page
- Validation and buttons as above, but instead of 'Save' it is using Create
- Add a text search to the pet listing
- Add the ability to switch the ordering to be by Name, DOB, Weight
# BookShop
This is a simple crud example system with a REST WebApi written in C# with .Net Core 2.2 and EntityFramework, using DDD and Clean Code concepts. The interface was built with React.

**This project was build and tested with Visual Studio at a Windows 10 machine, using an instance of Sql Server Express LocalDB for data storage.**

## Dependencies
- .net Core 2.2
- Sql Server Express LocalDB
- node/npm

## Hierarchy
- **Application:** This layer is the application front door. It's responsible of receiving all requests and redirecting it to the correct services, or serving the user interface content.
- **Domain:** This layer contains the Entities and Interfaces necessary to the business domain that we're trying to recreate. The other layers must use and obey the interfaces here defined.
- **Infra:** Responsible to query and persist the Domain Entities. This layer can also port Utility classes to be used by the other layers .
- **Service:** Heart of the project. This folder contains the Services responsible of validating data, applying business logic and send the entity to the Infra layer persist. These services don't need to know how or where the data is gonna be stored, it isn't their responsibility.

## Setup
Make sure all dependencies are installed. After it, execute do the `migrations`:
- First open the NuGet Console (Tools -> NuGet Package Manager -> Package Manager Console)
- In **Default project** select the option `BookShop.Infra`
- Execute the command `Update-Database`. If everything is ok, it'll return a message: **Done.**

## Execution
To execute the project, open **Visual Studio**, just select on top bar at **Startup Project** the item `BookShop.Application` and click on the Green button on the right side.

**The first Build is gonna be slow because it'll install the NPM dependencies for the React Interface.**

## API Samples
Postman Collection: https://www.getpostman.com/collections/cd7b7cc935de12c5d40b
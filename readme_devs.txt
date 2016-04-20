Prerequisites
SQL Server Express, recommended SQL Server Managment Studio & Profiler aswell
https://www.microsoft.com/en-us/download/details.aspx?id=42299

Project structure
1. katselabor.database - use it to sync your database with project and vice versa. This is the way all developers are on the same page on whats happening with database and can play on their own macines. Post-deployment script populates DB with default data for testing.
2. katselabor - asp.net mvc application for our frontend
3. katselabor.repos - our repository. Very loosly following DDD pattern.

NuGet
We use NuGet to keep project settings up to date. We are using Nlog for logging and Entity Framework for ORM. DI is done by MVC framework sort-off. Recomended to look Automapper and nInject for more powerful experience.

General logic:
* Interface represents a contract, while you can have several implementations of that contract in different (abstract) classes.
* Repository gives you: persistence, OO View of the data, Data Access Logic Abstraction, Query Access Logic
* Controller gets data from repository, fills model and returns view
* Model contains the data filled by controller
* View knows how to show data from the model

EF

Each entity in EDM is mapped with the database table. You can check the entity-table mapping by right clicking on any entity in the EDM designer -> select Table Mapping. Also, if you change any property name of the entity from designer then the table mapping would reflect that change automatically.
*.Context.tt: This T4 template file generates a context class whenever you change Entity Data Model (.edmx file).The context class resides in {EDM Name}.context.cs file. The default context class name is {DB Name} + Entities. 

Sample syntax
    using (var ctx = new katselaborEntities())
    {
        ctx.generationHistorySets.Add(resultInput);                
        ctx.SaveChanges();

        logger.Info("Saving to db " + resultInput.result);
    }
# SchoolManagementApp
A simple students management system with the next modules management:

- Students.
- Teachers.
- Grades.
- Enrollments.


## Running migrations
In order to be able of running migrations, you can do it with the `dotnet ef` command tools or with the Packages Manager Console.

Also, you can run migrations from the script `database_scripts.sql` located in the `Scripts` folder on the root of the project.

### Using EF Core Tools
If you are using the EF Core command Tools you need to open a console or navigate to the root directory of the project SchoolManagementApp at the same level of the `.sln` file, also you can specify the solution on the command line, but placing the command line in the root directory helps avoid errors when specifying those paths when execution commands.

The next commands need to be run:

- Database Schema: Contains all the tables for the system. 
    ```
    dotnet ef database update --context SchoolDbContext --project .\SchoolManagementApp.Infrastructure\SchoolManagementApp.Infrastructure.csproj --startup-project .\SchoolManagementApp.Web\SchoolManagementApp.Web.csproj
    ```

### Packages Manager Console
If you are using the Packages Manager Console, you can open the console in Visual Studio IDE and use the Tools commands to run migrations. To open the Package Manager Console go to the IDE menu `Tools > Nuget Packages Manager > Packages Manager Console` this will open the Packages Manager Console and here you can run the commands to run migrations, just chose the **Default Project** as `SchoolManagementApp.Infrastructure`  and run the respective commands:

- Database Schema: Contains all the tables for the system. 
    ```
    Update-Database -Context SchoolDbContext
    ```

***IMPORTANT***: This project is using an SQLEXPRESS Server instance, if you are using LocalDB (or other SQL Server variant) change the connection string located in the `appsettings.json` file to match your SQL Server version. This should be done in order to be able running this project. I did not configure Docker or an in app database like SQLite for this project.
# Smart_Property_Rental_API
As part of my third-week ASP.NET Web API assignment project, I created a Property Rental application.

# Tech Stack Used: 
- ASP .NET Web API
-  JavaScript
-  AJAX
-  jQuery
-  HTML
-  CSS.

 ## Reuirements:
 - VS Code -> Updated version (newer).
 - dotnet -> New version.
 - VS Code Extensions -> C#, c#-extension tool, and code runner.
 - Server -> SQL Server Management Studio
 
 ## Process to run app
 - Establish four tables as shown in the Models folder with the following relation.
  ![schema drawio](https://user-images.githubusercontent.com/68849555/221851887-3385de83-41e6-4c5b-9da5-da6f6afcb874.png)
 - Create a new asp.net web api project -> dotnet new webapi --name ProjectName
 - cd ProjectName, code . (to open that project in VS Code).
 - Scaffold your database in your Models folder.
 - Install all dotnet packages by Microsoft.EntityFrameworkCore.Mvc like SqlServer, tools, Design, code-generator
 - Use your dbContext.cs in your controllers.
 - HTTP request methods are metioned there.
 - dotnet build
 - dotnet run --launch-profile https (run to https url link)
 - Goto Web API Swagger -> https://localhost:portNo/swagger/index.html 
 - Test your APIs here on swagger like Postman(API Testing tool).
 - Now open your Welcome.html file from UserInterface folder in your browser.
 - Register and Login using your Username and Password, then Logout successfully.

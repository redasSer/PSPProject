To set up a ASP.NET Core web application with Swagger follow these steps:

Install the .NET 6 Core SDK from the Microsoft website: https://dotnet.microsoft.com/download


Install the Swashbuckle.AspNetCore package, which provides support for generating Swagger documents and integrating Swagger UI into ASP.NET Core apps. In the terminal, navigate to the project directory (e.g. "MyApp") and run the following command:
'dotnet add package Swashbuckle.AspNetCore' 

Run the application using the dotnet command-line tool:
'dotnet run' 
This will start the web server and host your ASP.NET Core application. You can access the Swagger UI by navigating to http://localhost:(port)/swagger in your web browser, where (port) is the port number on which the application is running (e.g. 5000).

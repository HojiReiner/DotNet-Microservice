# DotNet Microservice

**Project from the course on .NET Microservices by Julio Casal**

[Video](https://www.youtube.com/watch?v=CqCDOosvZIk)
[Website](https://dotnetmicroservices.com/)

**!THE ORIGINAL COURSE IS IN .NET5 BUT I'VE DONE IT IN .NET6!**

## About

This project works as a backend server of an hipotetical videogame, and manages everything related to item economy

## Usefull commands
```bash
#Create .NET gitignore 
dotnet new gitignore

#Create .NET base webapi project
dotnet new webapi -n <name>

#Add package to project
dotnet add package <name>

#Add Library
dotnet add reference <path>.csproj

#Build Project
dotnet build

#Run Project
dotnet run

#Get an development HTTPS certificate
trust HTTPS development certificate:
dotnet dev-certs https --trust
```
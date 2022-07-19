# Play.Common

**Common functionalities that are use by all services**

## Usefull Commands

```pwsh
#Create a class project
dotnet new classlib -n <name>

#Package project in a nuget package
dotnet pack -o <path>

#Package with a different number
dotnet pack -p:PacakgeVersion=<number> -o <path>

#Declare packages source
dotnet nugget add source <path> -n <name>
```
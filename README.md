# Currencies  API

An API that manages Currencies and Currency rates written in .Net Core 

It is a Demo CRUD application.

## How to run


1. Download or clone the project.

2. Database setup:  You can leave the settings as is and use the in memory db or you can change the appsettings.json not to use inMemoryDB and use your Sql Server as below:

```c#
"AppSettings": {
    "UseInMemoryDatabase":"False",
...
  },
...
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=YOUR_DB_NAME;User Id=YOUR_DB_USER;Password=YOUR_PASSWORD;"
  }
```
3. In a terminal, navigate in the currency-api folder and run the command
```bash
dotnet run
```

4. Navigate to the [swagger endpoint](https://localhost:5001/swagger) to browse all the available endpoints and actions.

5. Go to the publicly available (unprotected) Auth login and Execute a POST call with the admin account (has all the roles and has unlimited access):
```javascript
{
  "userName": "admin",
  "password": "admin123",
}
```
Or the simple user account:
```javascript
{
  "userName": "user",
  "password": "user123",
}
```
You will receive a UserDTO object as an answer from the API. The Token property will be populated with the Api JWT access token.

6. On the Swagger UI top-right click on the "Authorize" button and enter:
```bash
Bearer _the_token_you_received_from _the_login_call_
```
And click Authorize.

Now you can browse in the API from the swagger UI.

## Features
* Code First Development with Entity Framework
* Thee Layer Achitecture with Controllers Layer, Business Logic Layer(Services), Data Layer (Repositories)
* Dependency Injection
* Repositories and Unit of work Patterns
* Abstract repository and central save logic
* Custom extensions methods
* Mapping to DTOs (viewModels) with AutoMapper
* Jwt Authentication
* Role based authorization
* Soft Deletion with query filters
* Auditing details on all entities by using a base model


## License
Feel free to use this code in your projects
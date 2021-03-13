# FoodRecipes

### MediatR and CQRS

I decided to use MediatR, because this library makes easy to implement CQRS patter.
In CQRS we have queries (when we can only return data) and commands (where we can only update data,
we don't want to return anything).

### FluentValidator

We should implement some validations to validate input data (I recommend FluentValidator),
and check if command/query/request is valid in ASP.NET Core middleware or
decorator.

### Logging

We should log every start and end of command/query. We could do that in ASP.NET Core middleware or
decorator. 

### OpenApi/Swagger

We can consume OpenApi here https://localhost:5001/swagger/v1/swagger.json. It's
Additionaly you can find documentation here: https://localhost:5001/swagger/index.html.

### ConnectionString in appsettings

This connectionstring is only for development. On production we should have some
kind of env variables or KeyVault.

### FoodRecipes.Domain

It's created for DDD purposes (e.g. Aggregates, ValueObjects, Entities).
As we don't have business logic here, I didn't implement anything there.

### EventSourcing

As one of the requirements is to have a history, we can decide to use EventSourcing (e.g Maven).

### Indexes

We should add indexes/unique indexes to the database.

### Endpoints

Code compiles, you can use 2 GET endpoints:
- https://localhost:5001/recipes - list of recipes
- https://localhost:5001/recipes/{id}, e.g https://localhost:5001/recipes/80F36ACE-2FC6-46F3-A86A-A59A927E5F46

### Project Implementation Points
We can discuss `Project Implementation Points` later, as I didn't manage to do everything I want.
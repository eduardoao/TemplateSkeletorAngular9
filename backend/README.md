[![Build Status](https://aelassas.visualstudio.com/store/_apis/build/status/aelassas.store?branchName=master)](https://aelassas.visualstudio.com/store/_build/latest?definitionId=2&branchName=master)
[![Azure DevOps tests](https://img.shields.io/azure-devops/tests/aelassas/store/2?logo=azure-pipelines)](https://aelassas.visualstudio.com/store/_build/latest?definitionId=2&branchName=master)

## Microservices Architecture

![Microservices Architecture](https://www.codeproject.com/KB/aspnet/5271708/microservices-logical.png)

A microservices architecture consists of a collection of small, independent, and loosely coupled services. Each service is self-contained, implements a single business capability, is responsible for persisting its own data, is a separate codebase, and can be deployed independently.

API gateways are entry points for clients. Instead of calling services directly, clients call the API gateway, which forwards the call to the appropriate services.

There are multiple advantages using microservices architecture:

- Developers can better understand the functionality of a service.
- Failure in one service does not impact other services.
- It's easier to manage bug fixes and feature releases.
- Services can be deployed in multiple servers to enhance performance.
- Services are easy to change and test.
- Services are easy and fast to deploy.
- Allows to choose technology that is suited for a particular functionality.

Before choosing microservices architecture, here are some challenges to consider:

- Services are simple but the entire system as a whole is more complex.
- Communication between services can be complex.
- More services equals more resources.
- Global testing can be difficult.
- Debugging can be harder.

Microservices architecture is great for large companies, but can be complicated for small companies who need to create and iterate quickly, and don't want to get into complex orchestration.

## Development Environment

- Visual Studio 2019
- .NET Core 3.1
- MongoDB
- Postman

## Technologies

- C#
- ASP.NET Core
- Ocelot
- Swashbuckle
- Serilog
- JWT
- MongoDB
- xUnit
- Moq
- HTML
- CSS
- JavaScript

## Architecture

![Architecture](https://www.codeproject.com/KB/aspnet/5271708/architecture.jpg)

There are three microservices:

- **Catalog microservice**: allows to manage the catalog.
- **Cart microservice**: allows to manage the cart.
- **Identity microservice**: allows to manage users.

Each microservice implements a single business capability and has its own MongoDB database.

There are two API gateways, one for the front end and one for the back end.

Below is the front end API gateway:

- **GET /catalog**: retrieves catalog items.
- **GET /catalog/{id}**: retrieves a catalog item.
- **GET /cart**: retrieves cart items.
- **POST /cart**: adds a cart item.
- **PUT /cart**: updates a cart item.
- **DELETE /cart**: deletes a cart item.
- **POST /identity/login**: performs a login.
- **POST /identity/register**: registers a user.
- **GET /identity/validate**: validates a JWT token.

Below is the back end API gateway:

- **GET /catalog**: retrieves catalog items.
- **GET /catalog/{id}**: retrieves a catalog item.
- **POST /catalog**: creates a catalog item.
- **PUT /catalog**: updates a catalog item.
- **DELETE /catalog/{id}**: deletes a catalog item.
- **POST /identity/login**: performs a login.
- **GET /identity/validate**: validates a JWT token.

Finally, there are two client apps. A front end for accessing the store and a back end for managing the store.

The front end allows registered users to see the available catalog items, allows to add catalog items to the cart, and allows to remove catalog items from the cart.

Here is a screenshot of the store page in the front end:

![Front end](https://www.codeproject.com/KB/aspnet/5271708/frontend.jpg)

The back end allows admin users to see the available catalog items, allows to add new catalog items, allows to update catalog items, and allows to remove catalog items.

Here is a screenshot of the store page in the back end:

![Back end](https://www.codeproject.com/KB/aspnet/5271708/backend.jpg)

## Source Code

![Source code](https://www.codeproject.com/KB/aspnet/5271708/solution.jpg?ref=1)

- **CatalogMicroservice** project contains the source code of the microservice managing the catalog.
- **CartMicroservice** project contains the source code of the microservice managing the cart.
- **IdentityMicroservice** project contains the source code of the microservice managing users.
- **Middleware** project contains the source code of common functionalities used by microservices.
- **FrontendGateway** project contains the source code of the front end API gateway.
- **BackendGateway** project contains the source code of the back end API gateway.
- **Frontend** project contains the source code of the front end client app.
- **Backend** project contains the source code of the back end client app.
- **test** solution folder contains unit tests of all microservices.

The source code is described on [CodeProject](https://www.codeproject.com/Articles/5271708/Microservices-using-ASP-NET-Core-Ocelot-MongoDB-an).

## How to Run the Application

You can run the application using IISExpress in Visual Studio 2019.

You will need to install MongoDB if it is not installed.

First, right click on the solution, click on properties and select multiple startup projects. Select all the projects as startup projects except Middleware project:

![vs](https://www.codeproject.com/KB/aspnet/5271708/vs-startup.jpg)

Then, press **F5** to run the application.

You can access the front end from http://localhost:44317/.

You can access the back end from http://localhost:44301/.

To login to the front end for the first time, just click on **Register** to create a new user and login.

To login to the back end for the first time, you will need to create an admin user. To do so, open Postman and execute the following **POST** request http://localhost:44397/api/identity/register with the following payload:

```json
{
  "email": "admin@store.com",
  "password": "pass",
  "isAdmin": true
}
```

You can also create the admin user using Swagger UI: http://localhost:44397/swagger

Finally, you can login to the back end with the admin user you created.

## How to Deploy the Application

You can deploy the application using Docker containers on Linux distributions.

You will need to install Docker and Docker Compose if they are not installed. 

First, copy the source code to a folder on your Linux machine.

Then open a terminal, go to that folder (where the .sln file is located) and run the following command:

```
docker-compose up
```

That's it, the application will be deployed and will run.

Then, you can access the front end from http://host-ip:44317/ and the back end from http://host-ip:44301/.

Here is a screenshot of the application running on Ubuntu:

![Docker](https://www.codeproject.com/KB/aspnet/5271708/docker.png)

## Further Reading

- [Microservices architecture style](https://docs.microsoft.com/en-us/azure/architecture/guide/architecture-styles/microservices)
- [Health monitoring](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/monitor-app-health)
- [Load balancing](https://ocelot.readthedocs.io/en/latest/features/loadbalancer.html)
- [Testing ASP.NET Core services](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/test-aspnet-core-services-web-apps)
- [Multistage build](https://docs.microsoft.com/en-us/visualstudio/containers/container-build?view=vs-2019#multistage-build)

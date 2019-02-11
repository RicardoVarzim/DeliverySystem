# DeliverySystem - Route Manager API

**Specifications**

 - Build distributed system using micro services architecture with .NET
   Core platform
 - Messaging using RabbitMQ
 - Store user identities and authenticate
 - CQRS, commands and events handlers design patterns
 - Unit and integration test
 - Deploy using Docker and Docker Compose

**Requirements**

 - C# programming language
 - Basic understanding of .NET Core platform
 - Basic understanding of HTTP API and distributed systems

**Enviorenment**

- Visual Studio 2019
- Docker for Windows
- mongodb

**System Architecture**

- HTTP API GateWay
- Service Bus
- Identity Service
- Activities Service

**Messaging**
- Configuring RabbitMQ service bus
- Creating Commands
- Creating Events
- Implementing Api endpoints
- Subscribing to the messages

**Domain Persistence**
- Creating domain models
- Setting up MongoDB
- Implementing repositories
- Creating application services
- Implementing handlers

**Unit and Integration Tests**
 - Api Testing
 - Services Testing

 **Dockerizing**
 - Running services using Docker
 - Docker Compose tool
 - Deploying application to the cloud

 **Swagger** 
 - Api exposed using swagger

 **Identity Service and implementation**
 - Json Web Tokens
 - Authenticating users with JWT

**TODO** 
- Neo4j Service
- Resolve Shortest Path 

** Getting Started **

- Publish
	- cd src
	- dotnet publish ./DeliveryService.Api -c Release -o ./bin/Docker; dotnet publish ./DeliveryService.Services.Points -c Release -o ./bin/Docker; dotnet publish ./DeliveryService.Services.Identity -c Release -o ./bin/Docker

- Docker Build
	- cd src
	- docker build -f .\DeliveryService.Api\Dockerfile -t deliveryservice.api .\DeliveryService.Api\; docker build -f .\DeliveryService.Services.Points\Dockerfile -t deliveryservice.services.points .\DeliveryService.Services.Points\; docker build -f .\DeliveryService.Services.Identity\Dockerfile -t deliveryservice.services.identity .\DeliveryService.Services.Identity\

- Docker Compose Run
	- cd scripts
	- docker-compose up

** Curl command for access basic functions **


** References **
 
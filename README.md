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
 - Storing Docker images in Hub
 - Deploying application to the cloud

**First Run Bash Commands**

- Docker RabbitMQ:
	> docker run -p 5672:5672 rabbitmq
- Run API:
	> dotnet run
- Run ActivityService:
	> dotnet run --urls "http://*.5050"
- Docker MongoDB:
	> docker run -d -p 27017:27017 mongo

** TODO** 
- Identity Service and implementation
- Neo4j Service
- Resolve Shortest Path
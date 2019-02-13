
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

**Environment**

- Visual Studio 2019
- Docker for Windows
- mongodb
- neo4j
- rabbitmq
- jwt

**System Architecture**

- HTTP API Gateway
- Identity Service
- Points Service

## Development

**Messaging**
- Configuring RabbitMq service bus
- Creating Commands
- Creating Events
- Implementing Api endpoints
- Subscribing to the messages

**Domain Persistence**
- Creating domain models
- Setting up MongoDb
- Implementing repositories
- Creating application services
- Implementing handlers

**Unit and Integration Tests**
 - Api Testing
 - Services Testing

 **Dockerizing**
 - Running services using Docker
 - Docker Compose tool

 **Swagger** 
 - Api exposed using swagger

 **Identity Service and implementation**
 - Json Web Tokens
 - Authenticating users with JWT
 
 **Neo4j**
 

## Usage
	

 - First build:
		 `cd DeliveryService; docker-compose up --build;`
		 
 - Usefull Commands:
		`docker-compose down`
		`docker stop $(docker ps -a -q)`
		`docker rm $(docker ps -a -q)`
		`docker rmi $(docker images -a -q)`

**Basic Functions**

## Exercise Overview

**Acknowledgements**
 - First time using docker and docker compose
 - Implementing Service Bus

**Difficulties**

 - Docker run with Api dependencies on RabbitMQ:
	problem: on docker compose the services didn't wait on the dependencies like MQ service, so at startup they closed.
	solution: `restart: on-failure` on api, points and identity services
 
 - Neo4j connect
	problem: Neo4jClient.GraphClient.Connect cannot assign requested address even though the Neo4j server was accessible throw browser
	solution: (TODO) The neo4j image needs to have a user and password different from the default in order to client get a connection. On docker compose neo4j image, setup `environment: NEO4J_AUTH: user:password`
 
## References
 - .NET Microservices: Architecture for Containerized .NET Applications https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/
 - .NET Core Microservices Course: https://www.packtpub.com/application-development/net-core-microservices-video
 - Docker CLI commands you can’t live without:  https://medium.com/the-code-review/top-10-docker-commands-you-cant-live-without-54fb6377f481
 - Neo4jClient wiki: https://github.com/Readify/Neo4jClient/wiki
 - Graph Algorithms in Neo4j: Shortest Path: https://neo4j.com/blog/graph-algorithms-neo4j-shortest-path/
 - A prototype web application for managing and visualizing refugees and hotspots: https://gitlab.com/efxa/refugee
 - Get started with Swashbuckle and ASP.NET Core: https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.2&tabs=visual-studio


**Future Work** 
- Neo4j Client Connect
- Resolve Shortest Path 
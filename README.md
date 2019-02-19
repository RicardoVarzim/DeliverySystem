
# DeliverySystem - Route Manager API

**Specifications**

 - Build distributed system using micro services architecture with .NET
   Core platform
 - Messaging using RabbitMQ
 - Store user identities and authenticate
 - CQS pattern, commands and events handlers design patterns
 - Unit and integration test
 - Deploy using Docker and Docker Compose
 - Store Graph and find shortest Path

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

**System Architecture Overview**

- HTTP API Gateway

This gateway works as a hub of commands registering and distributing the command through out the system using a MQ system namely rabbitMq. 

- Identity Service

Register and Validates User authentication

- Points Service

Stores and Queries a Neo4j graph Db and a mongo to store Point the related Connections. Retrieves the shortest Path between two Points.

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

- Create User
- Create Point
- Create Connection
- Login
- GetPoints
- GetPath

[![Run in Postman](https://run.pstmn.io/button.svg)](https://app.getpostman.com/run-collection/4a5cfee58ef0ff315de5)

## Exercise Overview

**Acknowledgements**
 - First time using docker and docker compose
 - Implementing a Messaging Bus
 - Basic Unit and Integration Test 
 - Cypher Queries
 - Salt Generator and Validation
 - CQRS pattern 

**Difficulties**

 - Mongo WiredTiger error:
	problem: Operation not permitted, no permissions to access data volume
	solution attemp 1: removed volume sharing on Mongo 

 - Docker run with Api dependencies on RabbitMQ:
	problem: on docker compose the services didn't wait on the dependencies like MQ service, so at startup they closed.
	solution: `restart: on-failure` on api, points and identity services
 
 - Neo4j Log Volume Sharing error:
	- solution: removed log volume sharing 

 - Neo4j connect
	problem: Neo4jClient.GraphClient.Connect cannot assign requested address even though the Neo4j server was accessible throw browser
	solution attempt 1: The neo4j image needs to have a user and password different from the default in order to client get a connection. On docker compose neo4j image, setup `environment: NEO4J_AUTH: user:password`
    solution attempt 2: nevermind Neo4jClient and use Neo4jDriver instead
	real solution: using neo4j docker-compose service tag instead of localhost 
  
**Conclusion**
	I'm proud of the final result of this exercise. A great challenge that gave me alot of knowledge and pratice. Ive come across alot of infrastructure problems, with composing the solution first of all, neo4j client. Besides the 
	technical issues, not related so much with programming and the logic of the system but with the system infrastructure it was a very valued experience.

## References
 - .NET Microservices: Architecture for Containerized .NET Applications https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/
 - .NET Core Microservices Course: https://www.packtpub.com/application-development/net-core-microservices-video
 - Docker CLI commands you can’t live without:  https://medium.com/the-code-review/top-10-docker-commands-you-cant-live-without-54fb6377f481
 - Neo4jClient wiki: https://github.com/Readify/Neo4jClient/wiki
 - Graph Algorithms in Neo4j: Shortest Path: https://neo4j.com/blog/graph-algorithms-neo4j-shortest-path/
 - A prototype web application for managing and visualizing refugees and hotspots: https://gitlab.com/efxa/refugee
 - Get started with Swashbuckle and ASP.NET Core: https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.2&tabs=visual-studio


## Future Work

- Life Check Service
- Continuos Integration Monotoring
- Profilling Tests

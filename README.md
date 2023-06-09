# Microsevice Template 

A boilerplate project which merges multiple concepts, practices, standars and patterns. This is a presonal project used mainly for learning and solidifing knowledge, but feel free to use this as you see fit.

## Table of Contents
- [Microsevice Template](#microsevice-template)
  - [Table of Contents](#table-of-contents)
- [Getting Started](#getting-started)
- [Goals](#goals)
- [Design Decisions and Dependencies](#design-decisions-and-dependencies)
  - [Architecture](#architecture)
    - [Template.Domain](#templatedomain)
    - [Template.Persistence](#templatepersistence)
    - [Template.Application](#templateapplication)
    - [Template.Infrastructure](#templateinfrastructure)
    - [Template.Presentation](#templatepresentation)
    - [Template.Host](#templatehost)
    - [Template.Outbox](#templateoutbox)
- [Design Patterns](#design-patterns)
  - [Mediator](#mediator)
  - [Repository](#repository)
  - [Specification](#specification)
- [Integration Patterns](#integration-patterns)
  - [Outbox](#outbox)
- [Appendix](#appendix)

# Getting Started
# Goals
# Design Decisions and Dependencies

## Architecture
---

The base shape of the project is build on the core concepts of [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html). You will notice that the project structure is a bit more complex than the usual clean architecture boilerplate, but at the point of creating this repository it feels the most appropriate approach to structure the code.

You may recognize some parts of familiar code or even design choices. Like previously mentioned, this has started as a learning project, and as such I have also been influenced by brilliant minds which I will mention in the [Appendix](#appendix).

### Template.Domain
---

This is the core of the application. It's the assembly that contains the bussiness models, as well as the primitive types used as building blocks for all the different objects defined throughout the application. You might find them familliar, since they are written using the popular example from [eShopOnContainers](https://github.com/dotnet-architecture/eShopOnContainers).

```
IAggregateRoot.cs
IEntity.cs
IEnumeration.cs
IEvent.cs
IEventBus.cs
IRepository.cs
IUnitOfWork.cs
IValueObject.cs
```

Ideally, this assembly should not referrence any 3rd parties where possible. If you want, you can create your own interfaces to emulate the 3rd party interface and wrap the functionality at a level above. This might be overkill in small projects but if it doesn't add much overhead to your development process, it's my opinion it's best you don't couple external dependencies in the core of your bussiness model.

You will find in this assembly things like
* Aggregates
* Entities
* Views
* Enums
* [Repository](#repository) (Interface)
* Domain Events


### Template.Persistence
---

This is the data access part of the application. There are examples out there that usually bundle together the domain and the persistence responsabilites in the same assembly, and with good reason in most of the cases. 

It's my personal preference, however, to keep them separated if possible. It discourages directly using the database context (using ef core) and instead relying on the repository interfaces defined in the [Template.Domain](#templatedomain) assembly.
This way you are less inclined to couple your application code with the 3rd party for database access.

You will find in this assembly things like
* Database Contexts
* Database Migrations
* Value Converters
* [Repository](#repository) (Implementation)
* [Specification](#specification)


### Template.Application
---

This is the where the bulk of the application bussiness logic is situated. This assembly, together with [Template.Domain](#templatedomain), is the center of the [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) design. You usually find this assembly commonly described as 'core', and it's perfectly fine to have the three assemblies merged together ([Template.Application](#templateapplication), [Template.Persistence](#templatepersistence), [Template.Domain](#templatedomain)) into a single 'Template.Core' if you do not want the extra complexity.

You will find in this assembly things like

* [Mediator](#mediator) 
* Domain Event Handlers
* Commands
* Queries
* Notifications (Integration Events)
* [Repository](#repository) (Implementation)
* [Specification](#specification)


### Template.Infrastructure

This is the place for external dependencies. It's the assembly that will hold most of the logic and services which integrate with external parties. It's also the assembly where you can add mappers and middlewares if you feel the need to. Generally, any non bussiness critical piece of code should be added in the infrastructure layer.

Yes, one could argue that the data access could be places here instead of the lower core level. I find that by doing that, you need to add extra boiler plate for creating different models and mappings for the domain models and data entities. It very much depends on what other constraints you have when starting development. For situations where you create a new project, with no prior data existing, I prefer using the same entities for the domain models and the data models; it's just easier that way.

You will find in this assembly things like

* Mappers
* Services
* HTTP Clients
* SOAP Services
* Middleware

### Template.Presentation

This is the place where we design the interaction with the end user of our application. It mainly contains the entrypoint(s) in the application, be it MVC, WebAPI or other types of services.

You will find in this assembly things like

* Controllers
* Endpoint Definitions
* Routing 
* Authorization
* Authentication
  

### Template.Host

This is the startup assembly. You can combine it with the [Template.Presentation](#templatepresentation) assembly instead of having two assemblies. I for one find it easier to manage and configure the application when I only have a couple of files to look at.

You will find in this assembly things like

* AppSettings
* Startup Code

### Template.Outbox

# Design Patterns
## Mediator
## Repository
## Specification
# Integration Patterns
## Outbox


# Appendix
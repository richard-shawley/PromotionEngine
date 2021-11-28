# Promotion Engine

## Application Architecture

The application is written in C# 10 using .Net 6. If using Visual Studio you will need to use VS2022 in order to build and run the application.

The application is split into three layers as per DDD and Microservice best practice. Although the application is a console app I felt this segregation still made sense.

### Application Layer

**Shopping.Application**

The application layer contains a console application. It builds a service provider in order to use DI.

It then seeds data and provides a simple interface to allow items to be added and removed from a cart in order to checkout.

### Domain Layer

**Shopping.Domain**

This layer contains models that provide business logic for a cart, checkout and the promotion engine. It also contains entities for products and promotions which would be fetched from a data store via the product and promotion services. It also included the contract for the promotion and product repositories.

### Infrastructure Layer

**Shopping.Infrastucture**

This layer contains in memory respositories to provide persistence. If this application was to be productionised these would be replaced with repositories that would handle integration with the chosen database.

## Tests

The solution contains two test projects.

**Shopping.Specs**

This project uses SpecFlow to define the three scenarios outlined in the brief. The test use Moq to mock the IPormotionService used by the PromotionEngine to get promotions. 

**Shopping.Tests**

This project contains fine grained unit tests written with NUnit and FluentAssertions.

## Todo

- Make sure all methods have parameter validation.
- Add entity validation.
- Add logging.
- Add more unit tests.
- Consider using CQRS in the application layer.

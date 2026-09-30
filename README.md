# KFC Menu API

## Project Description

This project is a KFC Menu and Inventory Management Web API developed using ASP.NET Core Web API and Entity Framework Core.

The API manages menu categories, menu items, ingredients, and inventory.

## Technologies Used

* C#
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Swagger
* N-Tier Architecture

## Project Structure

* KFCMenuAPI - Controllers and API
* KFCMenuAPI.BLL - Services and DTOs
* KFCMenuAPI.DAL - Database Context and Repositories
* KFCMenuAPI.Model - Entity Models

## Main Entities

* Category
* MenuItem
* Ingredient
* Inventory

## Relationships

* One Category can have many MenuItems.
* MenuItems can have many Ingredients.
* Each Ingredient has one Inventory record.

## API Features

* Create, Read, Update and Delete operations
* DTOs
* Validation
* Async/Await
* Entity Framework Core
* Swagger API testing
* Error handling

## Database

Database: KFCMenuAPI

SQL Server:
PRABHJOT04\SQLEXPRESS

## Testing

The API endpoints were tested using Swagger.

Screenshots of the API testing are included in the `Screenshots` folder.

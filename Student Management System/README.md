# Student Management System 

## Overview

This project is a Student Management System developed using ASP.NET Core Web API.  
It performs basic CRUD operations for managing student records and includes JWT Authentication for secure API access.

The project follows layered architecture using Controller, Service, and Repository layers.



# Features

- Get all students
- Get student by Id
- Add new student
- Update existing student
- Delete student
- JWT Authentication
- Global Exception Handling Middleware
- Swagger API Documentation
- Serilog Logging
- SQL Server Database Integration


# Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger
- Serilog

# Database Details

Database Name: StudentDB

Table Name: Students

Table Columns:

| Column      | Type     |
|------------ |----------|
| Id          | int      |
| Name        | nvarchar |
| Email       | nvarchar |
| Age         | int      |
| Course      | nvarchar |
| CreatedDate | datetime |



# Project Structure

Controllers
Services
Repository
Models
DTOs
Middleware
Data


# Setup Steps

## 1. Clone the Repository

git clone <repository-url>

## 2. Open the Project

Open the solution in Visual Studio 2022.


## 3. Configure SQL Server Connection

Update connection string inside `appsettings.json`

Example:

"ConnectionStrings": {
  "DefaultConnection": "Server=AKANSHA\\MSSQLSERVER01;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;"
}


#4. Run Migration

Open Package Manager Console and run:

Add-Migration InitialCreate
Update-Database



## 5. Run the Application

bash - dotnet run


# Swagger URL

https://localhost:7281


# JWT Authentication

## Generate Token

Use: http POST /api/Auth/login


## Authorize API

Click the `Authorize` button in Swagger and enter: token

# API Endpoints

## Get All Students

http
GET /api/Students


## Get Student By Id

http
GET /api/Students/{id}


## Add Student

http
POST /api/Students

Sample Request:

json
{
  "name": "Akansha",
  "email": "akansha@gmail.com",
  "age": 22,
  "course": "Computer Science"
}


## Update Student

http
PUT /api/Students/{id}

## Delete Student

http
DELETE /api/Students/{id}

# Logging

Serilog is used for logging application details into console and log files.

Log files are stored inside: Logs


# Exception Handling

Global Exception Middleware is implemented to handle runtime exceptions and return proper error responses.


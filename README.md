
# Albellicart .NET Core GraphQL API

## Quick Start
```
> run\run-windows.bat
> browse to http://localhost:3000/ui/playground
```

## Planning & Documentation
Confluence - https://techfactor.atlassian.net/l/c/HE5GnM1C

## Tech-Stack

| Component        	| Attribute					| Value  	| Status  | Reference |
| ------------- 	|:-------------:			| -----:	| -----: | -----: |
| Web API | Repository | https://github.com/ThePravinDeshmukh/albelli-cart | Done |
|  | Framework | dotnet 3.1 | Done |
|  | ORM | EF Core | Done |
|  | API Querying | GraphQL | Done |
|  | Logging | ?? | NOT STARTED |
|  | Tests | XUnit with Moq | In Progress |
|  |  |  |  |
|  |  |  | EF Core tests |
|  |  |  |  |
|  |  |  | Graphql endpoint tests |
|  |  |  |  |
|  | Code Coverage | Cobertura | Done |
|  | Service Discovery | Eureka | NOT STARTED |
|  | Code Analysis | EnableNETAnalyzers | Done |
| Database | Options - | As confirmed, using In-memory for demonstration. | Done |
|  |  |  |  |
|  | In-memory SQL |  |  |
|  |  |  |  |
|  | NoSql |  |  |
|  |  |  |  |
|  |  |  |  |
| Deployment and Runtime | Container | Docker | DONE |
|  |  |  |  |
|  |  |  |  |
|  |  |  |  |
|  | Windows | Dotnet core 3.1 runtime | Done |
|  |  |  |  |
|  |  |  |  |
|  |  |  |  |


## GraphQL

GraphQL is query language for API.
GraphQL provides a complete and understandable description of the data in your API, gives clients the power to ask for exactly what they need and nothing more, 
makes it easier to evolve APIs over time, and enables powerful developer tools.

https://graphql.org

### Query - Get All Orders

You can open playground localhost:5000/ui/playground and run below query
``` 
query{
  orders
  {
    id
    orderLine
    {
      productType
      quantity
    }
    requiredBinWidth
  }
} 
```

or pass query as argument to /graphql endpoint
``` http://localhost:5000/graphql?query={orders{id,orderLine{productType,quantity}requiredBinWidth}} ```


### Query - Get an Order

You can open playground localhost:5000/ui/playground and run below query
``` 
query{order(id: 1)
  {
    id
    orderLine
    {
      productType
      quantity
    }
    requiredBinWidth
  }
} 
```

![](img/get-order.JPG)

or pass query as argument to /graphql endpoint
``` http://localhost:5000/graphql?query={order(id:1){id,orderLine{productType,quantity}requiredBinWidth}} ```

### Mutation - Create an Order

```
mutation($order: [OrderLine]!){
  createOrder(orderlines: $order)
  {
    id,
    requiredBinWidth,
    orderLine
    {
      productType
      quantity
    }
  }
}
```
and add query variables

```
{
  "order": [
    {"productType": "PHOTO_BOOK","quantity": 1},
    {"productType": "CALENDAR","quantity": 2},
    {"productType": "MUG","quantity": 4}
  ]
}
```

![](img/create-order.JPG)

The JSON request for this mutation would look like:
```
{
  "query": "mutation ($orderlines:[OrderLine]!){ createOrder(orderlines: $orderlines) { id, requiredBinWidth, orderLine {productType, quantity } } }",
  "variables": {
      "orderlines": [
        {"productType": "PHOTO_BOOK","quantity": 13},
        {"productType": "CALENDAR","quantity": 2},
        {"productType": "MUG","quantity": 7}
      ]
  }
}
```
mutation ($orderlines:[OrderLine]!){ createOrder(orderlines: $orderlines) { id, requiredBinWidth, orderLine {productType, quantity } } }

# How to Generate Coverage Report

You can generate coverage report for solution and view in html

Run
```coverage\generate-coverage.bat```

This will 
    Run Tests in solution
    Generate coverage report in html
    Open report in browser

# How to Run

You can run Web API on target as Windows or in Docker container.

##Docker

    Required - Docker Engine Installed https://docs.docker.com/engine/install/

Run
```run\run-docker.bat```

## Windows 
Prerequisite

	Required - Dotnet Core 3.1 SDK  https://dotnet.microsoft.com/download/dotnet/3.1
	Optional - Visual Studio 2019  https://visualstudio.microsoft.com/vs/
Run
```run\run-windows.bat```

 

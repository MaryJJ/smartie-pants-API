![Logo](https://smartie-pants-webapp.herokuapp.com/assets/images/Smartie-pants-logo.png)

"Surround yourself with successful people. You can't be what you can't see."

# Smartie Pants Placements

Smartie Pants Placements is a project to manage placements in [Unity](https://unity.com/) plataform, the system allows us to access information through a REST API.

Basic Actions:

- Create a user and login.
- Create and update placements in Unity.
- Visualize the response from Unity API after creating or updating placements.

This project is a [ASP .Net Core 3.1](https://docs.microsoft.com/en-us/dotnet/fundamentals) REST API, it uses [PostgreSQL](https://www.postgresql.org/) as a database and works independently of the visual client, we recommended using the visual interface you will find [here](https://github.com/MaryJJ/smartie-pants-WebApp)

## Developing

```shell
git clone https://github.com/MaryJJ/smartie-pants-API.git
```

## Initial Configuration

Configure the variables in appsettings.json file.

```sh
  // Token for authetication with Unity API
  "UnityAPI": {
    "Token": "UNITY_API_TOKEN" 
  },
  
  // Variables to create jwt Token for authentication with the API
  "Jwt": {
    "Issuer": "https://smartie-pants-api.herokuapp.com", 
    "Secret": "JWT_SECRET",
    "ExpirationInDays": 30
  },
  
  // Database connection settings
  "ConnectionStrings": {
    "Default": "CONNECTION_STRING"
  },
```

## Getting started

1. Run migrations:

```sh
dotnet ef --startup-project .\SmartiePants.Api database update
```

2. Launch application, and open `https://localhost:5001` in your browser:

```sh
dotnet publish -c Release -o /publish
dotnet /publish/SmartiePants.Api.dll
```

## Deploying/Publishing

Automatic deploy to [Heroku](https://www.heroku.com) with [Docker](https://www.docker.com) and [Github Actions](https://github.com/features/actions):

```shell
.github/workflows/main.yml
```

The environment variables: HEROKU_API_KEY, UNITY_API_TOKEN, JWT_SECRET, CONNECTION_STRING were set in [Github Secret](https://docs.github.com/es/actions/reference/encrypted-secrets).

## Project structure

```
SmartiePants.Api/            point of access for application
SmartiePants.Core/           application's foundation, hold contracts (interfaces …), 
                             models and everything else that is essential
SmartiePants.Data/           access layer
SmartiePants.Services/       business logic
```

## Links

Demo online: (the online demo when first loaded may take a while as the project is hosted on a free dino on Heroku and this dino falls asleep if it has no activity so the first load needs to reactivate the dino.)

- WebApp: https://smartie-pants-webapp.herokuapp.com
- Api: https://smartie-pants-api.herokuapp.com/api
- Swagger documentation: https://smartie-pants-api.herokuapp.com/index.html

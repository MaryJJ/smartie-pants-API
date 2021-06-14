![Logo](https://smartie-pants-webapp.herokuapp.com/assets/images/Smartie-pants-logo.png)

"Surround yourself with successful people. You can't be what you can't see."

# Smartie Pants Placements

Smartie Pants Placements is a project to manage placements in [Unity](https://unity.com/) plataform, the system allows us to access information through a REST API.

Basic Actions:

- Create a user and login.
- Create and update placements in Unity.
- Visualize the response from Unity API after creating or updating placements.

This project is a [ASP .Net Core 3.1](https://docs.microsoft.com/en-us/dotnet/fundamentals) REST API and works independently of the visual client, we recommended using the visual interface you will find [here](https://github.com/MaryJJ/smartie-pants-WebApp)

## Developing

```shell
git clone https://github.com/MaryJJ/smartie-pants-API.git
```

## Initial Configuration

Run migrations.

```sh
src/environments/environment.ts - development environment
src/environments/environment.prod.ts - production environment

Example
serverUrl: 'https://localhost:5001/api'
```

## Getting started

1. Go to project folder and install dependencies:

```sh
npm install
```

2. Launch development server, and open `localhost:4200` in your browser:

```sh
npm start
```

## Deploying/Publishing

Automatic deploy to [Heroku](https://www.heroku.com) with [Docker](https://www.docker.com) and [Github Actions](https://github.com/features/actions):

```shell
.github/workflows/main.yml
```

The environment variable HEROKU_API_KEY was set in [Github Secret](https://docs.github.com/es/actions/reference/encrypted-secrets).

## Project structure

```
dist/                        web app production build
e2e/                         end-to-end tests
src/                         project source code
|- app/                      app components
|  |- core/                  core module (singleton services and single-use components)
|  |- shared/                shared module  (common components, directives and pipes)
|  |- app.component.*        app root component (shell)
|  |- app.module.ts          app root module definition
|  |- app-routing.module.ts  app routes
|  +- ...                    additional modules and components
|- assets/                   app assets (images, fonts, sounds...)
|- environments/             values for various build environments
|- theme/                    app global scss variables and theme
|- index.html                html entry point
|- main.scss                 global style entry point
|- main.ts                   app entry point
|- polyfills.ts              polyfills needed by Angular
+- test.ts                   unit tests entry point
```

## Links

Demo online: (the online demo when first loaded may take a while as the project is hosted on a free dino on Heroku and this dino falls asleep if it has no activity so the first load needs to reactivate the dino.)

- WebApp: https://smartie-pants-webapp.herokuapp.com
- Api: https://smartie-pants-api.herokuapp.com/api
- Swagger documentation: https://smartie-pants-api.herokuapp.com/index.html

# Main tasks

Task automation is based on [NPM scripts](https://docs.npmjs.com/misc/scripts).

| Task                                            | Description                                                                                        |
| ----------------------------------------------- | -------------------------------------------------------------------------------------------------- |
| `npm start`                                     | Run development server on `http://localhost:4200/`                                                 |
| `npm run build [-- --configuration=production]` | Build web app for production (with [AOT](https://angular.io/guide/aot-compiler)) in `dist/` folder |
| `npm test`                                      | Run unit tests via [Karma](https://karma-runner.github.io) in watch mode                           |
| `npm run e2e`                                   | Run e2e tests using [Protractor](http://www.protractortest.org)                                    |
| `npm run lint`                                  | Lint code                                                                                          |

The default build configuration is `prod`.

## Additional tools

Tasks are mostly based on the `angular-cli` tool. Use `ng help` to get more help or go check out the
[Angular-CLI README](https://github.com/angular/angular-cli).

#### Libraries

- [Angular](https://angular.io)
- [Angular Material](https://material.angular.io)
- [Angular Flex Layout](https://github.com/angular/flex-layout)
- [Material Icons](https://material.io/icons/)
- [RxJS](http://reactivex.io/rxjs)

### eazy-transact-backend-dotnet-version

# EAZY-TRANSACT

Eazy-Transact is a smooth peer-2-peer transactions service. It gives fast, secure and flexible funds transfer. 


## Home Page
[homepage](https://eazy-transact.herokuapp.com)

## Getting Started
Clone the Repo.
-------------
`https://github.com/Alpha1202/EAZY-TRANSACT.git`
## Prerequisites
The following tools will be needed to run this application successfully:
* Node v10.15.0 or above
* Npm v6.4 or above
## Endpoints
- POST **api/user/signup** A user can create an account

- POST **api/user/signin** A registered user can login
- POST **/api/transaction/send** An authenticated user can intiate fund transfer
- POST **/api/transaction/transfer** With a valid OTP, an authenticated user can successfully transfer funds

## Installation
**On your Local Machine**
- Pull the [develop](https://github.com/Alpha1202/EAZY-TRANSACT.git) branch off this repository
- Run `npm install` to install all dependencies
- Run npm start to start the app
- Access endpoints on **localhost:2020**

## Built With
* [Asp.net](https://dotnet.microsoft.com/) - Runtime-Enviroment
* [Mongodb](https://www.mongodb.com/) - The World's Most Advanced Open Source transactional Database
* [mailgun](https://www.mailgun.com/)

## Api Documentation
[Api Documentation](https://eazy-transact.herokuapp.com/api-docs/)

## Authors
* **Nzubechukwu Nnamani**

# ProjetDeTestGestionEmployee
ProjetTest - Guide d'installation et d'utilisation

1) Prérequis

Docker Desktop installé et en fonctionnement

Docker Compose

.NET 9 SDK

Node.js & Angular CLI

2) Backend (.NET 8)

Étapes :

Se placer dans le répertoire backend (Projettest)

docker-compose build --no-cache

docker-compose up -d

Swagger : http://localhost:7006/swagger/index.html # url de swagger

3) Frontend (Angular)

Étapes :

cd ProjetFront

npm install

Configurer apiUrl dans environment.ts : 'http://localhost:7006/api'


Accéder à l’application avec la commande : ng serve -o

4) SQL Server Docker

Port exposé : 1433

Container : projettest_db

Mot de passe SA : Admin@1234

Base de données : ProjetEmploye

5) Notes importantes

Swagger : /swagger/index.html

Port backend : 7006

6) Commandes utiles

docker-compose build --no-cache

docker-compose up -d

docker-compose down

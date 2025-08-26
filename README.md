# ProjetDeTestGestionEmployee
ProjetTest - Guide d'installation et d'utilisation

1) Prérequis

Docker Desktop installé et en fonctionnement

Docker Compose

.NET 9 SDK

Node.js & Angular CLI

2) Backend (.NET 8)

Fichiers importants : Program.cs, appsettings.json, Dockerfile, docker-compose.yml

Étapes :

Se placer dans le répertoire backend (Projettest)

docker-compose build --no-cache

docker-compose up -d

Swagger : http://localhost:7006/swagger/index.html # url de swagger

Chaîne de connexion SQL Server : Server=localhost,1433;Database=ProjetEmploye;User Id=sa;Password=Admin@1234;

3) Frontend (Angular)

Étapes :

cd ProjetFront

npm install

Configurer apiUrl dans environment.ts : 'http://localhost:7006/api'

ng serve -o

Accéder à l’application : http://localhost:4200

4) SQL Server Docker

Port exposé : 1433

Container : projettest_db

Mot de passe SA : Admin@1234

Base de données : ProjetEmploye

Healthcheck automatique inclus

5) Notes importantes

Swagger : /swagger/index.html

Port backend : 7006

Warnings DataProtection dans Docker peuvent être ignorés pour dev

6) Commandes utiles

docker-compose build --no-cache

docker-compose up -d

docker-compose down

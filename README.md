## CRUD DDD CQRS usando mediatR

### Rodar o banco de dados
• Para rodar o banco de dados rodei os comando do docker

### Baixar a img do SQL 2019
`docker pull mcr.microsoft.com/mssql/server:2019-latest`

### Roda o container
`docker run --name testesqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=1q2w3e4r@#$" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest`
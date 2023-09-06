# CityManager API

## Persistance
### Migrations
```
dotnet-ef --startup-project ./src/CityManager.Api/ --project ./src/CityManager.Infrastructure/ migrations add CreateSchema --output-dir Persistence/Migrations
```
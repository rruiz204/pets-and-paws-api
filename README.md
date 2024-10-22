# Pets & Paws

### Common Commands
- Start the application

```bash
$ dotnet run --project ./src/Presentation/Presentation.csproj 
```


- Create a new migration

```bash
$ dotnet ef migrations add <NAME> -o Database/Migrations/<DB> -p ./src/Infrastructure -s ./src/Presentation -c <CONTEXT>
```


- Run migrations:

```bash
$ dotnet ef database update -p ./src/Infrastructure -s ./src/Presentation -c <CONTEXT>
```
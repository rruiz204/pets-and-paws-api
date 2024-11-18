# Pets & Paws

### Common Commands
- Create a new migration

```bash
$ dotnet ef migrations add <NAME> -o Database/Migrations -p ./src/Infrastructure
```

- Run migrations

```bash
$ dotnet ef database update -p ./src/Infrastructure
```
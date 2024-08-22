FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["pets-and-paws-api.csproj", "./"]
RUN dotnet restore "pets-and-paws-api.csproj"

COPY . .
RUN dotnet build "pets-and-paws-api.csproj" -c Release -o /build

FROM build AS publish
RUN dotnet publish "pets-and-paws-api.csproj" -c Release -o /publish

FROM base AS final
WORKDIR /app

COPY --from=publish /publish .
ENTRYPOINT ["dotnet", "pets-and-paws-api.dll"]
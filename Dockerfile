FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /khaos

COPY pets-and-paws-api.sln .
COPY /src ./src

RUN dotnet restore
FROM build AS publish

WORKDIR /khaos/src/Presentation
RUN dotnet publish Presentation.csproj -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=publish /publish .
ENTRYPOINT [ "dotnet", "Presentation.dll" ]
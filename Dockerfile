FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /building

COPY pets-and-paws-api.sln .
COPY /src ./src

RUN dotnet restore

WORKDIR /building/src/Presentation
RUN dotnet build Presentation.csproj -c Release -o /build

FROM build AS publish
RUN dotnet publish Presentation.csproj -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=publish /publish .
ENTRYPOINT [ "dotnet", "Presentation.dll" ]
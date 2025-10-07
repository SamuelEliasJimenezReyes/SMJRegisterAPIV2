FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["SMJRegisterAPIV2.csproj", "./"]
RUN dotnet restore "SMJRegisterAPIV2.csproj"

COPY . .

RUN dotnet publish "SMJRegisterAPIV2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=build /app/publish .

RUN mkdir -p /app/wwwroot/camper-documents

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

ENTRYPOINT ["dotnet", "SMJRegisterAPIV2.dll"]

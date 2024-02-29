FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["task_volgograd.ansoft.ru/task_volgograd.ansoft.ru.csproj", "task_volgograd.ansoft.ru/"]
RUN dotnet restore "task_volgograd.ansoft.ru/task_volgograd.ansoft.ru.csproj"
COPY . .
WORKDIR "/src/task_volgograd.ansoft.ru"
RUN dotnet build "task_volgograd.ansoft.ru.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "task_volgograd.ansoft.ru.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "task_volgograd.ansoft.ru.dll"]

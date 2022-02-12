FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DatabaseApi.csproj", "DatabaseApi/"]
#COPY "localdb.db" "DatabaseApi/"
RUN dotnet restore "DatabaseApi/DatabaseApi.csproj"
WORKDIR "/src/DatabaseApi"
COPY . .
#RUN dotnet build "DatabaseApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DatabaseApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY "localdb.db" .
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DatabaseApi.dll"]


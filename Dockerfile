FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE $PORT

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["AppointmentApi.csproj", "."]
RUN dotnet restore "./AppointmentApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "AppointmentApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppointmentApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppointmentApi.dll"]

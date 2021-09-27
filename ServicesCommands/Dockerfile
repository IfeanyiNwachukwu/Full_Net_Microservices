FROM mcr.microsoft.com/dotnet/sdk:5.0 As build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ServicesCommands.dll"]
# EXPOSE 8080

# ENV ASPNETCORE_URLS=http://+:8080

# # Creates a non-root user with an explicit UID and adds permission to access the /app folder
# # For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
# RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
# USER appuser

# FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
# WORKDIR /src
# COPY ["ServicesPlatform/ServicesPlatform.csproj", "ServicesPlatform/"]
# RUN dotnet restore "ServicesPlatform/ServicesPlatform.csproj"
# COPY . .
# WORKDIR "/src/ServicesPlatform"
# RUN dotnet build "ServicesPlatform.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "ServicesPlatform.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "ServicesPlatform.dll"]

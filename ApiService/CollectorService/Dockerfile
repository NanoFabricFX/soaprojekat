#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
#EXPOSE 42385
#EXPOSE 42329
#EXPOSE 1883

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["CollectorService/CollectorService.csproj", "CollectorService/"]
RUN dotnet restore "CollectorService/CollectorService.csproj"
COPY . .
WORKDIR "/src/CollectorService"
RUN dotnet build "CollectorService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CollectorService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CollectorService.dll"]
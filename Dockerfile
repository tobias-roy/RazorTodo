FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RazorProject.csproj", "./"]
RUN dotnet restore "RazorProject.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "RazorProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RazorProject.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RazorProject.dll"]

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CooperlinkLocationWorker.Application/CooperlinkLocationWorker.Application.csproj", "CooperlinkLocationWorker.Application/"]
COPY ["CooperlinkLocationWorker.Services/CooperlinkLocationWorker.Services.csproj", "CooperlinkLocationWorker.Services/"]
COPY ["CooperlinkLocationWorker.Persistence/CooperlinkLocationWorker.Persistence.csproj", "CooperlinkLocationWorker.Persistence/"]
COPY ["CooperlinkLocationWorker.Domain/CooperlinkLocationWorker.Domain.csproj", "CooperlinkLocationWorker.Domain/"]
COPY ["CooperlinkLocationWorker.Infrastructure/CooperlinkLocationWorker.Infrastructure.csproj", "CooperlinkLocationWorker.Infrastructure/"]
RUN dotnet restore "CooperlinkLocationWorker.Application/CooperlinkLocationWorker.Application.csproj"
COPY . .
WORKDIR "/src/CooperlinkLocationWorker.Application"
RUN dotnet build "CooperlinkLocationWorker.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CooperlinkLocationWorker.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CooperlinkLocationWorker.Application.dll"]
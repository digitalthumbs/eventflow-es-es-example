FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["SampleEventFlowApp/SampleEventFlowApp.csproj", "SampleEventFlowApp/"]
RUN dotnet restore "SampleEventFlowApp/SampleEventFlowApp.csproj"
COPY . .
WORKDIR "/src/SampleEventFlowApp"
RUN dotnet build "SampleEventFlowApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SampleEventFlowApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SampleEventFlowApp.dll"]
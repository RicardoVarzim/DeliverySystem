FROM microsoft/dotnet:2.1-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk-stretch AS build
WORKDIR /src
COPY ["src/DeliveryService.Services.Points/DeliveryService.Services.Points.csproj", "src/DeliveryService.Services.Points/"]
COPY ["src/DeliveryService.Common/DeliveryService.Common.csproj", "src/DeliveryService.Common/"]
RUN dotnet restore "src/DeliveryService.Services.Points/DeliveryService.Services.Points.csproj"
COPY . .
WORKDIR "/src/src/DeliveryService.Services.Points"
RUN dotnet build "DeliveryService.Services.Points.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DeliveryService.Services.Points.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV ASPNETCORE_URLS http://*:5050
ENV ASPNETCORE_ENVIRONMENT docker
ENTRYPOINT ["dotnet", "DeliveryService.Services.Points.dll"]
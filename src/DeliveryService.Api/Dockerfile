FROM microsoft/dotnet:2.1-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk-stretch AS build
WORKDIR /src
COPY src/DeliveryService.Api/DeliveryService.Api.csproj src/DeliveryService.Api/
COPY src/DeliveryService.Common/DeliveryService.Common.csproj src/DeliveryService.Common/
RUN dotnet restore src/DeliveryService.Api/DeliveryService.Api.csproj
COPY . .
WORKDIR /src/src/DeliveryService.Api
RUN dotnet build DeliveryService.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish DeliveryService.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT docker
ENTRYPOINT ["dotnet", "DeliveryService.Api.dll"]

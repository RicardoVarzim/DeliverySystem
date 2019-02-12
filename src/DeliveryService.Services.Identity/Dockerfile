FROM microsoft/dotnet:2.1-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk-stretch AS build
WORKDIR /src
COPY ["src/DeliveryService.Services.Identity/DeliveryService.Services.Identity.csproj", "src/DeliveryService.Services.Identity/"]
COPY ["src/DeliveryService.Common/DeliveryService.Common.csproj", "src/DeliveryService.Common/"]
RUN dotnet restore "src/DeliveryService.Services.Identity/DeliveryService.Services.Identity.csproj"
COPY . .
WORKDIR "/src/src/DeliveryService.Services.Identity"
RUN dotnet build "DeliveryService.Services.Identity.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DeliveryService.Services.Identity.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV ASPNETCORE_URLS http://*:5051
ENV ASPNETCORE_ENVIRONMENT docker
ENTRYPOINT ["dotnet", "DeliveryService.Services.Identity.dll"]
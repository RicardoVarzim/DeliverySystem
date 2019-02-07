FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY *.sln ./
COPY src/DeliveryService.Services.Points/DeliveryService.Services.Points.csproj src/DeliveryService.Services.Points/
COPY src/DeliveryService.Common/DeliveryService.Common.csproj src/DeliveryService.Common/
RUN dotnet restore
COPY . .
WORKDIR /src/src/DeliveryService.Services.Points
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DeliveryService.Services.Points.dll"]

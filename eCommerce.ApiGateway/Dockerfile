# Est�gio de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar os arquivos .csproj e restaurar depend�ncias
COPY ["eCommerce.ApiGateway/eCommerce.ApiGateway.csproj", "eCommerce.ApiGateway/"]
COPY ["eCommerce.SharedLibrary/eCommerce.SharedLibrary.csproj", "eCommerce.SharedLibrary/"]
RUN dotnet restore "eCommerce.ApiGateway/eCommerce.ApiGateway.csproj"

# Copiar todo o c�digo fonte
COPY . .

# Build da aplica��o
WORKDIR "/src/eCommerce.ApiGateway"
RUN dotnet build "eCommerce.ApiGateway.csproj" -c Release -o /app/build

# Publica��o da aplica��o
RUN dotnet publish "eCommerce.ApiGateway.csproj" -c Release -o /app/publish

# Est�gio de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "eCommerce.ApiGateway.dll"]
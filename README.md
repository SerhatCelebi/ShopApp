# MultiShop E-Ticaret Projesi

## 📋 Proje Hakkında

MultiShop, modern mikroservis mimarisi kullanılarak geliştirilmiş kapsamlı bir e-ticaret platformudur. .NET 6.0 tabanlı bu proje, farklı veritabanı teknolojilerini (MongoDB, SQL Server, Redis) ve Identity Server ile güvenli kimlik doğrulama sistemini entegre eder.

## 🏗️ Mimari

Proje, mikroservis mimarisi prensipleri doğrultusunda aşağıdaki bileşenlerden oluşmaktadır:

### 🔧 Servisler

- **Catalog Service**: Ürün kataloğu yönetimi (MongoDB)
- **Basket Service**: Alışveriş sepeti yönetimi (Redis)
- **Discount Service**: İndirim kuponu yönetimi (SQL Server)
- **Order Service**: Sipariş yönetimi (Clean Architecture)
- **Cargo Service**: Kargo yönetimi (Layered Architecture)
- **Identity Server**: Kimlik doğrulama ve yetkilendirme
- **Web UI**: MVC tabanlı kullanıcı arayüzü

### 🛠️ Kullanılan Teknolojiler

- **.NET 6.0**: Ana framework
- **MongoDB**: Ürün katalog veritabanı
- **SQL Server**: Identity ve discount veritabanları
- **Redis**: Sepet cache sistemi
- **JWT Bearer Authentication**: Güvenlik
- **AutoMapper**: Object mapping
- **Entity Framework Core**: ORM
- **Swagger/OpenAPI**: API dokümantasyonu
- **ASP.NET Core MVC**: Frontend framework

## 🚀 Kurulum

### Ön Gereksinimler

- .NET 6.0 SDK
- Visual Studio 2022 / Visual Studio Code
- MongoDB
- SQL Server / SQL Server LocalDB
- Redis

### Veritabanı Kurulumu

1. **MongoDB**

   ```bash
   # MongoDB'yi başlatın
   mongod
   ```

2. **SQL Server**

   ```sql
   -- Identity veritabanı için
   CREATE DATABASE MultiShopIdentityDb;

   -- Discount veritabanı için
   CREATE DATABASE MultiShopDiscountDb;
   ```

3. **Redis**
   ```bash
   # Redis'i başlatın
   redis-server
   ```

### Proje Kurulumu

1. Repository'yi klonlayın:

   ```bash
   git clone <repository-url>
   cd MultiShop-master
   ```

2. Solution'ı derleyin:

   ```bash
   dotnet build MultiShop.sln
   ```

3. Veritabanı migration'larını çalıştırın:

   ```bash
   # Identity Server için
   cd IdentityServer/MultiShop.IdentityServer
   dotnet ef database update

   # Discount Service için
   cd Services/Discount/MultiShop.Discount
   dotnet ef database update

   # Order Service için
   cd Services/Order/Infrastructure/MultiShop.Order.Persistence
   dotnet ef database update

   # Cargo Service için
   cd Services/Cargo/MultiShop.Cargo.DataAccessLayer
   dotnet ef database update
   ```

## 🔧 Yapılandırma

### Connection String'leri Güncelleyin

**Identity Server** (`IdentityServer/MultiShop.IdentityServer/appsettings.json`):

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=MultiShopIdentityDb;user=sa;Password=YourPassword"
  }
}
```

**Discount Service** (`Services/Discount/MultiShop.Discount/appsettings.json`):

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\ProjectModels;initial Catalog=MultiShopDiscountDb;integrated Security=true"
  }
}
```

**MongoDB** (`Services/Catalog/MultiShop.Catalog/appsettings.json`):

```json
{
  "DatabaseSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "MultiShopCatalogDb"
  }
}
```

**Redis** (`Services/Basket/MultiShop.Basket/appsettings.json`):

```json
{
  "RedisSettings": {
    "Host": "localhost",
    "Port": 6379
  }
}
```

## 🎯 Çalıştırma

### Multiple Startup Projects Ayarlayın

Visual Studio'da solution properties'den aşağıdaki projeleri startup projects olarak ayarlayın:

1. `MultiShop.IdentityServer` (Port: 5001)
2. `MultiShop.Catalog` (Port: 7000)
3. `MultiShop.Basket` (Port: 7001)
4. `MultiShop.Discount` (Port: 7002)
5. `MultiShop.Order.WebApi` (Port: 7003)
6. `MultiShop.Cargo.WebApi` (Port: 7004)
7. `MultiShop.WebUI` (Port: 5000)

### Terminal'den Çalıştırma

Her servisi ayrı terminal penceresinde çalıştırabilirsiniz:

```bash
# Identity Server
cd IdentityServer/MultiShop.IdentityServer
dotnet run

# Catalog Service
cd Services/Catalog/MultiShop.Catalog
dotnet run

# Basket Service
cd Services/Basket/MultiShop.Basket
dotnet run

# Discount Service
cd Services/Discount/MultiShop.Discount
dotnet run

# Order Service
cd Services/Order/Presentation/MultiShop.Order.WebApi
dotnet run

# Cargo Service
cd Services/Cargo/MultiShop.Cargo.WebApi
dotnet run

# Web UI
cd Frontends/MultiShop.WebUI
dotnet run
```

## 📚 API Dokümantasyonu

Swagger UI'a aşağıdaki URL'lerden erişebilirsiniz:

- **Catalog API**: `https://localhost:7000/swagger`
- **Basket API**: `https://localhost:7001/swagger`
- **Discount API**: `https://localhost:7002/swagger`
- **Order API**: `https://localhost:7003/swagger`
- **Cargo API**: `https://localhost:7004/swagger`

## 🏢 Proje Yapısı

```
MultiShop-master/
├── Frontends/
│   └── MultiShop.WebUI/              # MVC Web Uygulaması
├── IdentityServer/
│   └── MultiShop.IdentityServer/     # Kimlik Doğrulama Servisi
├── Services/
│   ├── Basket/
│   │   └── MultiShop.Basket/         # Sepet Mikroservisi
│   ├── Cargo/
│   │   ├── MultiShop.Cargo.EntityLayer/
│   │   ├── MultiShop.Cargo.DataAccessLayer/
│   │   ├── MultiShop.Cargo.BusinessLayer/
│   │   ├── MultiShop.Cargo.DtoLayer/
│   │   └── MultiShop.Cargo.WebApi/   # Kargo API
│   ├── Catalog/
│   │   └── MultiShop.Catalog/        # Katalog Mikroservisi
│   ├── Discount/
│   │   └── MultiShop.Discount/       # İndirim Mikroservisi
│   └── Order/
│       ├── Core/
│       │   ├── MultiShop.Order.Domain/
│       │   └── MultiShop.Order.Application/
│       ├── Infrastructure/
│       │   └── MultiShop.Order.Persistence/
│       └── Presentation/
│           └── MultiShop.Order.WebApi/ # Sipariş API
└── MultiShop.sln
```

## 🔒 Güvenlik

- JWT Bearer token tabanlı kimlik doğrulama
- Identity Server 4 entegrasyonu
- API'ler arası güvenli iletişim
- HTTPS zorunluluğu

## 🧪 Test

```bash
# Unit testleri çalıştırın
dotnet test

# Belirli bir proje için test
dotnet test Services/Catalog/MultiShop.Catalog.Tests
```

## 📦 Docker Desteği

Proje Docker ile containerize edilebilir. Her mikroservis için Dockerfile oluşturabilir ve docker-compose kullanabilirsiniz.



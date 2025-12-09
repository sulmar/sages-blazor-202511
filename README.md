# Examples from the Blazor Application Development Training

## Introduction

Welcome to the repository with materials for the **Blazor Application Development** training.

To get started with this course, you will need the following:

1. [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0).

## Setup
1. Clone the Git repository
```bash
git clone https://github.com/sulmar/...
```

## Podsumowanie Projektu

Ten projekt szkoleniowy demonstruje różne podejścia do tworzenia aplikacji Blazor oraz architekturę aplikacji opartą na warstwach. Rozwiązanie składa się z kilku projektów, które pokazują różne scenariusze użycia Blazor w praktyce.

### Struktura Rozwiązania

Rozwiązanie zawiera następujące projekty:

#### **Aplikacje Blazor**

1. **BlazorApp** (`src/BlazorApp/`)
   - Blazor WebAssembly aplikacja z integracją z zewnętrznym API
   - Demonstruje komunikację z backendem przez HTTP Client
   - Zawiera przykłady komponentów: Dashboard, Customers, Products
   - Używa SignalR do komunikacji w czasie rzeczywistym
   - Implementuje autoryzację z Bearer Token

2. **BlazorServerApp** (`src/BlazorServerApp/`)
   - Aplikacja Blazor Server
   - Demonstruje model hostingu po stronie serwera
   - Przykłady komponentów i routingu

3. **BlazorWebAssemblyApp** (`src/BlazorWebAssemblyApp/`)
   - Podstawowa aplikacja Blazor WebAssembly
   - Demonstruje podstawowe funkcjonalności Blazor WASM

#### **Backend i API**

4. **Api** (`src/Api/`)
   - RESTful API z ASP.NET Core
   - Zawiera endpointy dla Customers i Products
   - Implementuje SignalR Hub dla Dashboard (komunikacja w czasie rzeczywistym)
   - Background Service do generowania danych w czasie rzeczywistym
   - Używa OpenAPI/Swagger do dokumentacji API

5. **IdentityProvider.Api** (`src/IdentityProvider.Api/`)
   - Serwis autoryzacji i uwierzytelniania
   - Implementuje JWT Token Service
   - Zawiera różne implementacje hashowania haseł (Argon2, BCrypt)
   - Przykład architektury Identity Provider

#### **Warstwy Domenowe**

6. **Domain** (`src/Domain/`)
   - Warstwa domenowa z modelami biznesowymi
   - Abstrakcje repozytoriów (ICustomerRepository, IProductRepository)
   - Modele: Customer, Product, BaseEntity

7. **Infrastructure** (`src/Infrastructure/`)
   - Implementacje repozytoriów (InMemoryCustomerRepository, InMemoryProductRepository)
   - Generatory danych testowych (Fakers) używające biblioteki Bogus
   - Warstwa infrastruktury oddzielona od logiki biznesowej

### Architektura

Projekt demonstruje architekturę opartą na warstwach (Layered Architecture):

```
┌─────────────────────────────────────┐
│   Blazor Applications (Frontend)    │
│  - BlazorApp (WASM + API)           │
│  - BlazorServerApp                  │
│  - BlazorWebAssemblyApp             │
└──────────────┬──────────────────────┘
               │ HTTP / SignalR
┌──────────────▼──────────────────────┐
│   API Layer                         │
│  - Api (REST API + SignalR Hub)    │
│  - IdentityProvider.Api             │
└──────────────┬──────────────────────┘
               │
┌──────────────▼──────────────────────┐
│   Domain Layer                      │
│  - Models                           │
│  - Abstractions (Interfaces)        │
└──────────────┬──────────────────────┘
               │
┌──────────────▼──────────────────────┐
│   Infrastructure Layer              │
│  - Repository Implementations       │
│  - Data Fakers                      │
└─────────────────────────────────────┘
```

### Główne Funkcjonalności

- **Komponenty Blazor**: Przykłady komponentów wielokrotnego użytku (CustomersTable, ProductsTable, DebounceSearchInput)
- **Komunikacja z API**: Demonstracja HTTP Client z autoryzacją Bearer Token
- **SignalR**: Komunikacja w czasie rzeczywistym między aplikacją a serwerem
- **Routing**: Przykłady routingu w aplikacjach Blazor
- **Dependency Injection**: Wzorce DI w Blazor
- **Formularze i Walidacja**: Przykłady formularzy z walidacją
- **Layout i Styling**: Przykłady layoutów i stylizacji komponentów

### Materiały Szkoleniowe

W katalogu `docs/` znajdują się materiały szkoleniowe:
- Dokumentacja składni Razor
- Metody cyklu życia komponentów Blazor
- Atrybuty komponentów
- Dobre praktyki
- Dokumentacja CLI dla Blazor

W katalogu `excercises/` znajdują się ćwiczenia praktyczne:
- Dashboard Page
- Product Landing Page
- Product List Page
- Product Form Validation
- Product Search Panel
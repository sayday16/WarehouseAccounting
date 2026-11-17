# Warehouse Accounting

Desktop application for warehouse accounting built with .NET 8, C# and WPF.

## Features

- CRUD for Products, Product Categories, Warehouses and Currencies
- Exchange rate synchronization with the National Bank of Ukraine (NBU) API
  - On startup the user is offered to update rates if they were not updated today
  - Base currency is USD (rate = 1), all rates are relative to USD
  - Product prices in base currency are recalculated after each update
- Separate window for editing a warehouse: products in stock with quantities,
  total value of the warehouse in a selected currency
- Unique 8-digit barcode generated for each product (read-only)
- Optional: Code-128 barcode image preview

## Tech stack

- .NET 8, WPF, MVVM
- SQLite + Entity Framework Core (database is created automatically on first run)

## Project structure

```
src/
  WarehouseAccounting.Core   entities, data access, services
  WarehouseAccounting.App    WPF user interface
```

## Run

```bash
dotnet run --project src/WarehouseAccounting.App
```

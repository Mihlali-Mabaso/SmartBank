markdown
# 🏦 SmartBank - My EF Core Learning Journey

## 📅 Journey Log

### Day 1: Setting Up the Project (April 6, 2026)
**What I learned:**
- Created ASP.NET Core MVC project
- Set up Entity Framework Core
- Learned about DbContext and entity relationships

**Challenges faced:**
- Understanding one-to-many relationships
- Figuring out foreign keys

**Solutions:**
- Used the Contoso University example as reference
- Implemented Student → Enrollment → Course pattern for Customer → Account → Transaction

**Code added today:**
- Customer, Account, AccountType models
- Initial migration

---

## 🎯 Project Overview

A digital banking system built with ASP.NET Core and EF Core, inspired by FNB's pain points.

## 🏗️ Tech Stack
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server (LocalDB)
- C# (.NET 7/8)

## Phase 1: Data Layer - Complete! ✅

```mermaid
graph TD
    A[Entity Models<br/>Customer.cs, Account.cs, etc.] --> B[BankDbContext.cs<br/>DbSets + Configuration]
    B --> C[Add-Migration InitialCreate<br/>Creates migration files]
    C --> D[Update-Database<br/>Executes against SQL Server]
    D --> E[(SQL Server Database<br/>SmartBankDB)]
    
    style A fill:#4CAF50,stroke:#333,stroke-width:2px
    style B fill:#2196F3,stroke:#333,stroke-width:2px
    style C fill:#FF9800,stroke:#333,stroke-width:2px
    style D fill:#FF9800,stroke:#333,stroke-width:2px
    style E fill:#9C27B0,stroke:#333,stroke-width:2px

## 🚀 How to Run This Project

```bash
# Clone the repository
git clone https://github.com/Mihlali-Mabaso/SmartBank.git

# Navigate to project
cd SmartBank

# Restore packages
dotnet restore

# Update database (creates and seeds)
dotnet ef database update

# Run the application
dotnet run


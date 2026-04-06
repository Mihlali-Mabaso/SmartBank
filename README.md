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

![Status](https://img.shields.io/badge/status-in%20development-yellow)
![.NET Version](https://img.shields.io/badge/.NET-7.0-purple)
![EF Core](https://img.shields.io/badge/EF%20Core-7.0-blue)

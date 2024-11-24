# Bank Account Management System

A robust and scalable system for managing **Current Accounts** and **Savings Accounts**, with features like global lockdown functionality, transaction auditing, and thread-safe operations.

## Features

### Account Management
- **Current Account**: Supports overdraft limits for withdrawals.
- **Savings Account**: Limits withdrawals to a maximum of 10% of the account balance per transaction.
- Handles deposits and withdrawals with strict validation rules.

### Transaction Auditing
- Logs every deposit and withdrawal with a unique transaction ID, timestamp, and type.
- Supports retrieving transaction histories by account.

### Global Lockdown
- A centralized LockDownManager that restricts all account operations (deposits and withdrawals) during lockdown periods.
- Lockdown status is communicated to all accounts globally.

### Modular and Testable Design
- **IDateService**: Abstracts date/time operations for real-world and test environments.
- Follows **SOLID principles** for extensibility and maintainability.
- Thoroughly unit-tested.

## Technologies
- **Language**: C#
- **Framework**: .NET
- **Design Patterns**: Dependency Injection, Factory Pattern
- **Testing**: NUnit/xUnit/MSTest
- **Thread Safety**: `lock`, `ConcurrentDictionary`

## Getting Started

### Prerequisites
- .NET SDK installed (version 6.0 or higher)
- A C# IDE or editor like Visual Studio, Visual Studio Code, or Rider

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/kamucell/KamuAccountTransactionDemo1


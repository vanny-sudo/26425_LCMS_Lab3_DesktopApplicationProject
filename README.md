# 26425_LCMS_Lab3_DesktopApplicationProject

# Legal Case Management System

A desktop application for managing legal cases, clients, lawyers, hearings, and user accounts from one clear workspace.

> **Project idea:** Keep every case, person, hearing, and update connected in one place.

## Overview

The Legal Case Management System is a Windows desktop application built with **C#**, **.NET 10**, **Windows Forms**, and **MySQL Database**.

The system uses role-based access so each person sees the tools that match their work:

- **Admin** manage users, clients, cases, lawyers, and hearings and make summary reports.
- **Lawyers** work with assigned cases, update case information, add notes and manage hearings.
- **Clients** view their own cases and hearings through a private client portal.

## Main Features

### User access

- Login and registration
- Role-based access for Admin, Lawyer, and Client
- Password hashing
- Client portal access limited to the signed-in client
- Profile editing

### Admin workspace

- Create Client and Lawyer accounts
- Update user details and passwords
- Delete user accounts safely
- Manage client records
- Register and assign legal cases
- View hearings and reports

### Case management

- Generate case numbers
- Register new cases
- Assign cases to clients and lawyers
- Track case type, status, court level, and dates
- Update case status
- Add case notes
- Search cases by case number, client, lawyer, or status

### Hearing management

- Schedule hearings
- Prevent conflicting hearing times
- View upcoming hearings
- Apply role-based hearing access

### Client portal

- View the signed-in client's cases
- View upcoming hearings
- View account information
- Keep client information private from other clients

### Desktop interface

- Responsive Windows Forms layouts
- Readable, expandable data grids
- Consistent colors and controls

## Architecture

The project follows a clear MVC structure:

```text
LegalCaseManagementSystem/
├── Controller/       Validation, application rules, and permissions
├── Model/            Domain classes and database access objects
├── Data/             Database connection helper
├── View/             Windows Forms screens and designers
├── Database/         SQL migrations and data scripts
└── Program.cs        Application startup and role routing
```

The normal request flow is:

```text
User action in a Form
        ↓
Controller validates the request
        ↓
DAO executes a database operation
        ↓
Controller returns the result
        ↓
Form refreshes the screen
```


## Requirements

Install the following before running the project:

- Windows
- Visual Studio 2026 or later
- .NET 10 SDK
- MySQL Server
- MySQL Workbench or another MySQL database tool

## Database Setup

1. Start MySQL Server.
2. Create a database named `LCMS_db`.
3. Run your base database setup script.
4. Run this migration when needed:

The profile-data script adds or updates phone numbers, addresses, and dates of birth for existing records. It is intended for local development and demonstration purposes.

## Database Connection

The connection is configured in:

```text
LegalCaseManagementSystem/Data/DatabaseHelper.cs
```

The default local connection is:

```text
Server=localhost;Port=3306;Database=LCMS_db;Uid=root;Pwd=;
```

## Run the Project

1. Clone the repository:

```bash
git clone https://github.com/your-username/LegalCaseManagementSystem.git
cd LegalCaseManagementSystem
```

2. Open the solution in Visual Studio.
3. Confirm that MySQL is running.
4. Confirm that `LCMS_db` exists and the connection string is correct.
5. Build the solution.
6. Run the project.
7. Sign in through the login screen.

The application opens the correct workspace based on the signed-in user's role.

## User Journey

### Administrator

1. Sign in.
2. Open **Manage Users**.
3. Create a Client or Lawyer account.
4. Review client records.
5. Register a legal case.
6. Assign a lawyer.
7. Schedule a hearing.

### Lawyer

1. Sign in.
2. View assigned cases.
3. Update case status.
4. Add notes.
5. Review hearings.
6. Generate reports.

### Client

1. Sign in.
2. Open the client portal.
3. View personal cases.
4. View scheduled hearings.
5. Review account information.

## Project Goals

This project demonstrates how a desktop business application can combine:

- A friendly graphical interface
- A relational database
- Role-based permissions
- MVC-style organization
- Practical legal case workflows
- Separation between UI and database logic

## Future Improvements

Possible future improvements include:

- Email and SMS reminders
- Document attachments
- Case timeline history
- Billing and payment tracking
- PDF and Excel exports
- Audit logs
- Stronger password hashing such as bcrypt.
- Secure configuration through environment variables
- Automated tests

## Contributing

Contributions are welcome:

1. Fork the repository.
2. Create a feature branch.
3. Make your changes.
4. Test the application.
5. Create a pull request with a clear description.

## Author

Created as a Legal Case Management System desktop application using C#, .NET 10, Windows Forms, and MySQL.

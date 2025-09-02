# PanelProject.cs

A comprehensive Panel application built with ASP.NET Core, featuring Identity management and Entity Framework Core integration.

## 📋 Table of Contents

- [About](#about)
- [Features](#features)
- [Technologies](#technologies)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Configuration](#configuration)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [API Endpoints](#api-endpoints)
- [Contributing](#contributing)
- [License](#license)

## 🎯 About

PanelProject.cs is a modern web panel application that provides comprehensive user management and administrative functionality. Built with ASP.NET Core and Entity Framework Core, it offers secure authentication, authorization, and user management capabilities through ASP.NET Core Identity.

## ✨ Features

- **User Authentication & Authorization**
  - User registration and login
  - Role-based access control
  - Password reset functionality
  - Email confirmation

- **Admin Panel**
  - User management dashboard
  - Role and permission management
  - System configuration
  - Activity monitoring

- **Security**
  - JWT token authentication
  - Password encryption
  - CSRF protection
  - Rate limiting

- **Database Integration**
  - Entity Framework Core
  - Code-first migrations
  - Seeded default data
  - SQL Server support

## 🛠️ Technologies

- **Backend**
  - ASP.NET Core 6.0+
  - Entity Framework Core
  - ASP.NET Core Identity
  - SQL Server / LocalDB

- **Frontend**
  - HTML5 / CSS3
  - JavaScript / jQuery
  - Bootstrap 5
  - Responsive design

- **Tools & Libraries**
  - AutoMapper
  - FluentValidation
  - Swagger/OpenAPI
  - NLog/Serilog

## 📋 Prerequisites

Before running this application, make sure you have the following installed:

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) or LocalDB
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)
- [Git](https://git-scm.com/)

## 🚀 Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yasinserhatpeker/PanelProject.cs.git
   cd PanelProject.cs
   ```

2. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

3. **Update connection string**
   
   Edit `appsettings.json` file:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=PanelProjectDb;Trusted_Connection=true;MultipleActiveResultSets=true"
     }
   }
   ```

4. **Apply database migrations**
   ```bash
   dotnet ef database update
   ```

5. **Run the application**
   ```bash
   dotnet run
   ```

6. **Open in browser**
   
   Navigate to `https://localhost:5001` or `http://localhost:5000`

## ⚙️ Configuration

### Database Configuration

The application uses Entity Framework Core with SQL Server. Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Your_Connection_String_Here"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

### Identity Configuration

Default Identity settings can be modified in `Program.cs` or `Startup.cs`:

```csharp
services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.User.RequireUniqueEmail = true;
});
```

## 📖 Usage

### Default Admin Account

After running the application for the first time, use these credentials:

- **Email:** admin@panelproject.com
- **Password:** Admin123!

> **Note:** Change the default password immediately after first login.

### User Registration

1. Navigate to `/Account/Register`
2. Fill in required information
3. Confirm email (if email service is configured)
4. Login with new credentials

### Admin Functions

- **User Management:** View, edit, and delete users
- **Role Management:** Create and assign roles
- **System Settings:** Configure application settings
- **Reports:** View system usage and activity logs

## 📁 Project Structure

```
PanelProject.cs/
├── Controllers/           # MVC Controllers
│   ├── AccountController.cs
│   ├── AdminController.cs
│   └── HomeController.cs
├── Data/                  # Database Context and Models
│   ├── ApplicationDbContext.cs
│   └── Migrations/
├── Models/                # Data Models and ViewModels
│   ├── User.cs
│   ├── Role.cs
│   └── ViewModels/
├── Views/                 # Razor Views
│   ├── Account/
│   ├── Admin/
│   └── Shared/
├── Services/              # Business Logic Services
├── wwwroot/               # Static files (CSS, JS, images)
├── appsettings.json       # Configuration
└── Program.cs             # Application entry point
```

## 🔗 API Endpoints

### Authentication
- `POST /api/auth/login` - User login
- `POST /api/auth/register` - User registration
- `POST /api/auth/logout` - User logout
- `POST /api/auth/refresh` - Refresh token

### User Management
- `GET /api/users` - Get all users (Admin only)
- `GET /api/users/{id}` - Get user by ID
- `PUT /api/users/{id}` - Update user
- `DELETE /api/users/{id}` - Delete user (Admin only)

### Roles
- `GET /api/roles` - Get all roles
- `POST /api/roles` - Create new role (Admin only)
- `PUT /api/roles/{id}` - Update role (Admin only)
- `DELETE /api/roles/{id}` - Delete role (Admin only)

## 🤝 Contributing

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### Development Guidelines

- Follow C# coding conventions
- Write unit tests for new features
- Update documentation as needed
- Ensure all tests pass before submitting PR

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 📞 Support

If you have any questions or issues, please:

1. Check the [Issues](https://github.com/yasinserhatpeker/PanelProject.cs/issues) section
2. Create a new issue if your problem isn't already reported
3. Contact the maintainer: [Yasin Serhat Peker](https://github.com/yasinserhatpeker)

## 🙏 Acknowledgments

- ASP.NET Core team for the excellent framework
- Entity Framework Core team
- Bootstrap team for the UI components
- All contributors who have helped improve this project

---

**Made by [Yasin Serhat Peker](https://github.com/yasinserhatpeker)**

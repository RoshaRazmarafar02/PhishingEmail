# Phishing Testing Platform

An ASP.NET MVC web application for conducting controlled phishing awareness campaigns. Administrators can create phishing email templates, target simulated users, send emails, and track interaction metrics through a live dashboard.

> **For educational and authorized security awareness testing only.**

## Features

- **Email Templates** — Create HTML phishing email templates linked to fake login pages (Google, Netflix, Mubis)
- **User Management** — Add and manage target users by email address
- **Email Dispatch** — Send templated phishing emails via SMTP with unique tracking tokens per recipient
- **Interaction Tracking** — Record when recipients open links and whether they submit credentials on fake pages
- **Analytics Dashboard** — Visualize sent/visited/submitted rates per campaign and per website

## Tech Stack

| Layer | Technology |
|-------|-----------|
| Framework | ASP.NET MVC 5 (.NET 4.7.2) |
| Language | C# |
| ORM | Entity Framework 6 |
| UI | Bootstrap 5 |
| Database | SQL Server |
| Email | MailKit / MimeKit |

## Prerequisites

- Visual Studio 2019 or later
- .NET Framework 4.7.2
- SQL Server (any edition)
- A Gmail account with an [App Password](https://support.google.com/accounts/answer/185833) enabled

## Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/RoshaRazmarafar02/PhishingEmail.git
   ```

2. **Restore the database**
   - Open SQL Server Management Studio (SSMS).
   - Create a new database named `PhishingPlatformDB`.
   - Run the schema from the included `Database Schema.png` as reference.

3. **Configure credentials**

   Open `PhishingPlatform/Web.config` and fill in the `appSettings` section:
   ```xml
   <add key="SmtpEmail"    value="your-email@gmail.com" />
   <add key="SmtpPassword" value="your-gmail-app-password" />
   ```

   Update the connection string to point to your SQL Server instance:
   ```xml
   <add name="PhishingPlatformDBConnectionString"
        connectionString="Data Source=YOUR_SERVER;Initial Catalog=PhishingPlatformDB;Integrated Security=True;..."
        providerName="System.Data.SqlClient" />
   ```

4. **Open and run**
   - Open `PhishingPlatform/PhishingPlatform.sln` in Visual Studio.
   - Build the solution (`Ctrl+Shift+B`).
   - Press `F5` to run.

## Project Structure

```
PhishingPlatform/
├── Controllers/
│   ├── AdminController.cs       # Login / signup for admins
│   ├── PhishingController.cs    # Template management, user targeting, email sending
│   └── ChartController.cs       # Dashboard analytics
├── Models/
│   ├── Admin.cs
│   ├── TemplateEmail.cs
│   ├── UsersModel.cs
│   └── WebsiteModel.cs
├── Views/
│   ├── Admin/                   # Login & signup pages
│   ├── Phishing/                # Templates & user test pages
│   ├── Chart/                   # Analytics dashboard
│   └── FakePage/                # Simulated phishing landing pages
├── PhishingEmails/              # ASPX fake login pages (Google, Mubis)
├── Content/                     # Custom CSS per fake site
├── css/ & js/                   # Bootstrap vendor files
└── Web.config                   # App configuration (credentials go here)
```

## Pages

| Page | Route | Description |
|------|-------|-------------|
| Admin Login | `/Admin/Index` | Admin authentication |
| Admin Signup | `/Admin/Signup` | Register a new admin |
| Dashboard | `/Chart/Dashboard` | Campaign analytics |
| Email Templates | `/Phishing/Templates` | Create / view phishing templates |
| User Testing | `/Phishing/UserTest` | Manage targets and send emails |
| Fake Google | `/FakePage/Google` | Simulated Google login page |
| Fake Netflix | `/FakePage/Netflix` | Simulated Netflix login page |
| Fake Mubis | `/FakePage/Mubis` | Simulated Mubis login page |

## Security Notes

- Never commit real credentials to the repository — use `Web.config` appSettings.
- This platform is intended for **authorized** phishing simulation only. Always obtain written consent before targeting any individual.

## License

This project is open source and available for educational use.

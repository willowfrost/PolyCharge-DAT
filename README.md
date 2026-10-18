# PolyCharge Data Collection and Analysis Platform

A web-based platform designed to collect, manage, analyze, and report manufacturing and test data for **PolyCharge layered capacitors**.

The platform is specified as a multi-user ASP.NET Core MVC application. It is intended to import Microsoft Excel data into a relational database, provide role-based access to administrative and reporting functions, and produce statistical reports that help evaluate manufacturing processes.

> **Project status:** This README summarizes the intended application described in the *PolyCharge Data Analysis Tool* specification, Version 1.0.0 (February 2023). Features listed here are requirements or design intentions; their implementation status has not been verified against the repository source code.
>
> **Confidentiality:** The source specification is marked **Confidential Information**. Confirm authorization before making this repository, its source code, or associated manufacturing datasets public.

## Objectives

- Centralize manufacturing and test data collected during layered-capacitor production.
- Import data from Microsoft Excel spreadsheets into a SQL Server relational database.
- Support multiple users with role-based access to application functions and data.
- Provide CRUD (create, read, update, delete) interfaces for managing database records.
- Enable statistical analysis across selected manufacturing runs, products, recipes, and production subdivisions.
- Present findings through interactive web pages and graphical reports.
- Make reports available as PDF downloads and, where configured, scheduled email deliveries.

## Planned Features

### Data collection and management

- Upload manufacturing and test data from Microsoft Excel workbooks.
- Store imported data in a relational database.
- Manage records through administrative CRUD dashboards.
- Support relational associations between entities, including junction/pivot tables where needed.
- Use Entity Framework database migrations for schema version management.

### Users and access control

- Public landing and informational pages.
- User registration with email verification.
- User login and authenticated profile pages.
- Role- and privilege-dependent dashboards, navigation, and report access.
- A default staff-member role for new users, as described in the specification.

### Analysis and reporting

- Filter and select manufacturing runs by criteria such as **recipe** and **product**.
- Analyze measurements by manufacturing subdivisions such as **section**, **lane**, or **card**.
- Display statistical results using charts including pie charts, bar charts, and distribution/bell-curve plots.
- View reports in the browser and download them as PDF files.
- Support scheduled PDF reports delivered by email to designated recipients.

## Planned Technology Stack

| Layer | Technology |
| --- | --- |
| Application framework | ASP.NET Core 7 MVC |
| Primary language/platform | C# / .NET |
| Development environment | Visual Studio 2022 |
| Web server | Microsoft Internet Information Services (IIS) |
| Database | Microsoft SQL Server 2022 |
| Database administration | SQL Server Management Studio (SSMS) |
| Data access and schema migrations | Entity Framework / Entity Framework Core |
| Front end | HTML, CSS, JavaScript, Bootstrap |
| Server-rendered views | Razor |
| Optional interactive client features | Blazor, if needed |
| Charting | DotNet Charting, as specified |
| Source control | Git / GitHub |

This stack reflects the original project specification and is not a claim that all dependencies are already installed or configured. ASP.NET Core 7 is the version named in the original 2023 specification; assess current support and upgrade requirements before new production deployment.

## Application Architecture

The specified design follows the ASP.NET Core **Model–View–Controller (MVC)** pattern:

```text
Web Browser
    |
    | HTTP Request
    v
IIS / ASP.NET Core Application
    |
    v
Routing Middleware
    |
    v
MVC Controller
    |---------------------> Models / Entity Framework
    |                               |
    v                               v
Razor View                     SQL Server 2022
    |
    | HTTP Response
    v
Web Browser
```

Controllers coordinate user requests, model operations, and view rendering. Entity Framework provides application-level access to SQL Server, while Razor and Bootstrap support the web user interface.

The intended page layout includes a shared header, role-dependent navigation panel, main content area, and optional communications panel.

## User Interface

The original design identifies the following major page types:

| Page | Purpose |
| --- | --- |
| Home | Public landing page and entry point |
| Registration | Account creation and email verification |
| Login | Authentication for registered users |
| Dashboard | Role-based navigation and administrative functions |
| Profile | Information about the authenticated user |
| Reports | Authorized manufacturing-data analyses and report outputs |

## Data and Reporting Workflow

1. An authorized user uploads an Excel file containing manufacturing or test data.
2. The application processes the input and stores relevant information in SQL Server.
3. Users select the desired production runs and report criteria.
4. The application retrieves and analyzes the selected measurements.
5. Results are displayed as browser-based tables or charts.
6. Reports can be exported to PDF; designated reports may also be emailed on a schedule.

The source document does **not** define the Excel workbook schema, validation rules, complete database model, statistical formulas, or report catalog. These require implementation-specific documentation.

## Development and Deployment

The specification describes two deployment phases:

1. **Initial development:** Host the application locally on a development system.
2. **Hosted deployment:** Move the application to an internet hosting provider under a separate service agreement.

For a developer environment, the intended prerequisites are Visual Studio 2022 (or a compatible .NET development environment), the appropriate .NET SDK, SQL Server 2022, and SQL Server management tools. IIS is the specified web server for hosted deployment.

**Repository-specific setup is not documented in the source specification.** Before publishing run instructions, confirm the actual solution/project filename, database configuration keys, required secrets, migration commands, seed data, authentication setup, and startup profile in the source repository. Do not commit production credentials, confidential datasets, or environment-specific connection strings.

## Quality, Security, and Data Protection

The project specification calls for practices that support data integrity and reduce loss risk. The proposed application includes authenticated access, role-based authorization, database migrations, and operational attention to hardware maintenance and data backups.

Detailed backup schedules, retention periods, recovery procedures, access-control matrices, and security tests are not defined in the source document and should be documented before production use.

## Documentation and Scope

This README is based on:

- **Document:** *PolyCharge Data Analysis Tool*
- **Version:** 1.0.0
- **Initial date:** January 31, 2023
- **Latest document date:** February 1, 2023

The document is a high-level design and requirements description. It does not establish the repository's current implementation state, build instructions, licensing terms, maintainers, or contribution policy. These should be added once verified.

## License

No open-source license is specified in the source document. **All rights are reserved unless the repository owner supplies an explicit license.**

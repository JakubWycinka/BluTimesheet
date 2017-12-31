# Timesheet

This application is designated to report time spent on particular task by employee. The supervisor can then generate interesting reports, such as time spent on particular project. Only backend is developed.

### Installing

Application is developed using Visual Studio 2017 and Microsoft SQL Server 2014.

For proper working you need to make sure that you have connection to your database.
You will need to change **connestion string**.

There are some example data in app that can be persisted to database via Entity Framework using Package Manager console and following command

```
PM> update-database
```

## Built With

* [ASP.NET](https://www.asp.net/)
* [EntityFramework](https://www.nuget.org/packages/EntityFramework/) - ORM
* [Unity](https://www.nuget.org/packages/Unity/) - Dependency Injection
* [Identity](https://www.nuget.org/packages/Microsoft.AspNet.Identity/) - Authentication

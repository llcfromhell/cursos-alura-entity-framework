# cursos-alura-entity-framework

Please, use Entity Framework 6.1.3.
Tested with visual studio 2015 and 2017. Dotnet 4.5

* Config app.config with connection string:

<connectionStrings>
<add name="LojaContextConnectionString" connectionString="Data Source=(localdb)\mssqllocaldb;Initial Catalog=lojaComEntity.Context.LojaContext;Integrated Security=True" providerName="System.Data.SqlClient" />
</connectionStrings>

Commands to run Entity Framework

* Install-Package EntityFramework
* Enable-Migrations
* Add-Migration
* Update-Database
* Update-Database –TargetMigration: xxx



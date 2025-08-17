[![.NET](https://github.com/aimenux/DistributedMemoryCacheDemo/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/aimenux/DistributedMemoryCacheDemo/actions/workflows/ci.yml)

# DistributedCacheDemo
```
Using distributed cache in web api applications
```

> In this repo, i m using a [distributed cache](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/distributed) in order to improve web api responsiveness.
>
> Distributed cache source can be configured to use :
> - [memory cache](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/distributed#distributed-memory-cache)
> - [redis cache](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/distributed#distributed-redis-cache)
> - [sql server cache](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/distributed#distributed-sql-server-cache)

> For redis cache, you can use docker to run redis server.
> ```bash
> docker run -d --name local-redis -p 6379:6379 redis/redis-stack-server:latest
> ```

> For sql server cache, you can use docker to run sql server.
> ```bash
> docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=@Pa5sw0rd!" -p 1433:1433 --name local-sqlserver -d mcr.microsoft.com/mssql/server:2022-latest
> ```
> Use the sql script `CreateDatabase.sql` in order to create the database `CacheDatabase`.
> 
> Use the global tool `dotnet-sql-cache` in order to create the table `CacheTable`.
> ```bash
> dotnet sql-cache create "Server=localhost,1433;Database=CacheDatabase;User Id=sa;Password=@Pa5sw0rd!;TrustServerCertificate=True;" dbo CacheTable
> ```

> The web api sample provided in this repo is based on :
>
> - a distributed cache in order to save/load cached websites
>
> - a service to compute content length for a white listed website
>
> - an exception filter to handle some exceptions as bad requests
>
> - a validation attribute to validate route parameters
>

> 📢 Distributed memory cache is useful for development and testing scenarios and is not intended for production environements. 📢

**`Tools`** : net 9.0, distributed cache, serilog
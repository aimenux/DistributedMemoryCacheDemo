[![.NET](https://github.com/aimenux/DistributedMemoryCacheDemo/actions/workflows/ci.yml/badge.svg)](https://github.com/aimenux/DistributedMemoryCacheDemo/actions/workflows/ci.yml)

# DistributedMemoryCacheDemo
```
Using distributed memory cache in web api applications
```

> In this repo, i m using a [distributed memory cache](https://docs.microsoft.com/en-us/aspnet/core/performance/caching/distributed?view=aspnetcore-5.0#distributed-memory-cache) in order to improve web api responsiveness.
>
> Distributed memory cache is useful for development and testing scenarios and is not intended for production environements.
>
> The web api sample provided in this repo is based on :
>
> - a distributed memory cache in order to save/load cached websites
>
> - a service to compute content length for a white listed website
>
> - an exception filter to handle some exceptions as bad requests
>
> - a validation attribute to validate route parameters
>

**`Tools`** : vs19, net 5.0, serilog, distributed memory cache
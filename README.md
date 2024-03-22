
# DeLijn.Net

A C# DeLijn API library for dotnet core 8, featuring automatic ratelimiting, caching and parsing.


## Installation

You will need to use [dotnet 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) to use this library.


[Import from nuget.org](https://www.nuget.org/packages/DeLijn.Net/)

```
  dotnet add package DeLijn.Net
```
    
## Documentation

Soon™


## FAQ

#### Why?

Because I wanted to implement cute bussy realtime data in my discord bot and there was no C# library for this API yet. And I am not processing raw http bodies, it sucks.

#### Can you please add support for .net6/.netstandard/... so I can use it in my old ass project I am too lazy to upgrade?

No (upgrade to .net8).

#### Are you ok?

No, this API is the worst piece of junk I've come accross in years. While the beta version is not usuable at all, v1 is not much better. Almost all endpoints return shit that makes no sense or doesn't belong there at all. This goes from properties that always have the same value to links to other endpoints. There's also four or more ways to indicate something is missing or null (<not present>, null, [], "?"). This is just the surface. You ask me if I am OK? No I am not OK. In fact I am so not OK I want to post this README on LinkedIn and shit on DeLijn which I won't do but you get the idea.

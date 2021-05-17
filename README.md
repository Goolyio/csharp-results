# csharp-results

A flexible library for wrapping responses and errors into a result object

## Problem

Every project seems to have its own generic results implementation as its not native to any .NET libraries. This seems silly to me and a lightweight flexible result package could be used instead. There have been a few packages that have tried to do this, the most popular being [FluentResults](https://github.com/altmann/FluentResults) but in my opinion it feels very rigid to use esspecially around error response types.

[Nuget](https://www.nuget.org/packages/CSharpResults/)

## Examples
Just return either the success type ```T``` or the error type ```E``` from a method that returns a ```Result<T, E>```
```csharp
using CSharpResults;

public Result<SuccessObject, ErrorObject> MethodWithResult()
{
    bool isSuccess = DetermineSuccess();
    return isSuccess ? new SuccessObject() : new ErrorObject();
}
```
To access the success value or the error value make sure you check to see if the result ```IsSuccess``` boolean property is true or false as trying to access the value whilst ```IsSuccess``` is false will throw an ```InvalidOperationException``` and vice versa.
```csharp
using CSharpResults;

public void DoStuff()
{
    Result<int, string> result = GetResult();
    if(result.IsSuccess)
    {
        //Do something with result.value
    }
    else
    {
        //Do something with result.error
    }
}
```

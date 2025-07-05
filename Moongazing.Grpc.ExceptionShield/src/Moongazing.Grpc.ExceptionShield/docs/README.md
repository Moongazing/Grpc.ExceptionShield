# Grpc.ExceptionShield

Global exception handling for gRPC services — clean, extensible, interceptor-based.

## 📦 Install

```bash
dotnet add package Grpc.ExceptionShield


Usage

builder.Services.AddGrpcExceptionShield();

app.MapGrpcService<MyGrpcService>()
   .AddInterceptor<GrpcExceptionInterceptor>();



 Custom Mapping

public class MyCustomMapper : IExceptionMapper
{
    public RpcException Map(Exception ex)
    {
        return ex switch
        {
            ApplicationException => new RpcException(new Status(StatusCode.Aborted, ex.Message)),
            _ => new RpcException(new Status(StatusCode.Internal, "Something went wrong"))
        };
    }
}

services.AddSingleton<IExceptionMapper, MyCustomMapper>();



Licensed under MIT by Tunahan Ali Ozturk.
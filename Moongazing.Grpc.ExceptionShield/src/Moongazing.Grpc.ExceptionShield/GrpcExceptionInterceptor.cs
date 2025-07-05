using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;

namespace Moongazing.Grpc.ExceptionShield;

public sealed class GrpcExceptionInterceptor : Interceptor
{
    private readonly IExceptionMapper exceptionMapper;
    private readonly ILogger<GrpcExceptionInterceptor> logger;

    public GrpcExceptionInterceptor(IExceptionMapper exceptionMapper, ILogger<GrpcExceptionInterceptor> logger)
    {
        this.exceptionMapper = exceptionMapper;
        this.logger = logger;
    }

    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            return await continuation(request, context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception in gRPC method {Method}", context.Method);
            var rpcEx = exceptionMapper.Map(ex);
            throw rpcEx;
        }
    }
}

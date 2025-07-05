using Grpc.Core;

namespace Moongazing.Grpc.ExceptionShield;

public sealed class DefaultExceptionMapper : IExceptionMapper
{
    public RpcException Map(Exception exception)
    {
        return exception switch
        {
            ArgumentNullException => new RpcException(new Status(StatusCode.InvalidArgument, exception.Message)),
            UnauthorizedAccessException => new RpcException(new Status(StatusCode.PermissionDenied, exception.Message)),
            NotImplementedException => new RpcException(new Status(StatusCode.Unimplemented, exception.Message)),
            InvalidOperationException => new RpcException(new Status(StatusCode.FailedPrecondition, exception.Message)),
            TimeoutException => new RpcException(new Status(StatusCode.DeadlineExceeded, exception.Message)),
            OperationCanceledException => new RpcException(new Status(StatusCode.Cancelled, exception.Message)),
            KeyNotFoundException => new RpcException(new Status(StatusCode.NotFound, exception.Message)),
            ApplicationException => new RpcException(new Status(StatusCode.Aborted, exception.Message)),
            AccessViolationException => new RpcException(new Status(StatusCode.DataLoss, exception.Message)),
            OutOfMemoryException => new RpcException(new Status(StatusCode.ResourceExhausted, exception.Message)),
            FormatException => new RpcException(new Status(StatusCode.InvalidArgument, exception.Message)),
            _ => new RpcException(new Status(StatusCode.Unknown, "An unexpected error occurred."))
        };
    }
}

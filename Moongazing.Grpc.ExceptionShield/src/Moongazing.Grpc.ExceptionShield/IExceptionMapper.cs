using Grpc.Core;

namespace Moongazing.Grpc.ExceptionShield;

public interface IExceptionMapper
{
    RpcException Map(Exception exception);
}

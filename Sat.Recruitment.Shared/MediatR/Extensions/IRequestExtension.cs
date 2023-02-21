using MediatR;
using Sat.Recruitment.Shared.Models.ResponseWrappers;

namespace Sat.Recruitment.Shared.MediatR.Extensions
{
    public interface IRequestWrapper<T> : IRequest<ServiceResult<T>>
    {

    }

    public interface IRequestHandlerWrapper<TIn, TOut> : IRequestHandler<TIn, ServiceResult<TOut>> where TIn : IRequestWrapper<TOut>
    {

    }
}

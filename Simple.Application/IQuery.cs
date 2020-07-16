using MediatR;

namespace Simple.Application
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}
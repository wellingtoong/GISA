using EasyNetQ;
using GISA.Core.Communication;
using GISA.Core.DomainObjects;
using System;
using System.Threading.Tasks;

namespace GISA.MessageBus
{
    public interface IMessageBus : IDisposable
    {
        bool IsConnected { get; }
        IAdvancedBus AdvancedBus { get; }

        void Publish<T>(T message) where T : Entity, IAggregateRoot;

        Task PublishAsync<T>(T message) where T : Entity, IAggregateRoot;

        void Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : class;

        void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class;

        TResponse Request<TRequest, TResponse>(TRequest request)
            where TRequest : Entity
            where TResponse : ResponseResult;

        Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : Entity
            where TResponse : ResponseResult;

        IDisposable Respond<TRequest, TResponse>(Func<TRequest, TResponse> responder)
            where TRequest : Entity
            where TResponse : ResponseResult;

        IDisposable RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder)
            where TRequest : Entity
            where TResponse : ResponseResult;
    }
}

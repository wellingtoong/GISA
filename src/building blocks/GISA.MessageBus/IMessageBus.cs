using EasyNetQ;
using GISA.Core.DomainObjects;
using GISA.Core.Messages.Integration;
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
            where TRequest : Entity, IAggregateRoot
            where TResponse : ResponseMessage;

        Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : Entity, IAggregateRoot
            where TResponse : ResponseMessage;

        IDisposable Respond<TRequest, TResponse>(Func<TRequest, TResponse> responder)
            where TRequest : Entity, IAggregateRoot
            where TResponse : ResponseMessage;

        IDisposable RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder)
            where TRequest : Entity, IAggregateRoot
            where TResponse : ResponseMessage;
    }
}

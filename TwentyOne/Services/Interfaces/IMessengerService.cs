using System;

namespace TwentyOne.Services.Interfaces
{
    public interface IMessengerService
    {
        void Register<T>(object recipient, Action<T> action);
        void UnRegister(object recipient);
        void Send<T>(T value);
    }
}

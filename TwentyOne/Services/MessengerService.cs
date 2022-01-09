using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using TwentyOne.Services.Interfaces;

namespace TwentyOne.Services
{
    public class MessengerService : IMessengerService
    {
        private Messenger Messenger => (Messenger)Messenger.Default;

        public void Register<T>(object recipient, Action<T> action)
        {
            Messenger.Register(recipient, action);
        }

        public void UnRegister(object recipient)
        {
            Messenger.Unregister(recipient);
        }

        public void Send<T>(T value)
        {
            Messenger.Send(value);
        }
    }
}

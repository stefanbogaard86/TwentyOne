using System;
using System.Threading.Tasks;
using TwentyOne.Services;
using TwentyOne.Services.Interfaces;
using Xamarin.CommunityToolkit.ObjectModel;

namespace TwentyOne.ViewModels.ViewModelBase
{
    public abstract class ViewModelBase : ObservableObject, IDisposable
    {
        protected readonly IMessengerService MessengerService;

        public ViewModelBase()
        {
            MessengerService = new MessengerService();
        }

        public virtual Task InitializeAsync() => Task.CompletedTask;

        public virtual void Register(){}

        public virtual void Unregister()
        {
            MessengerService.Unsubscribe(this);
        }

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                Unregister();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyOne.Extensions;
using TwentyOne.ViewModels.ViewModelBase;
using Xamarin.Forms;

namespace TwentyOne.Pages.Base
{
    public abstract class ContentPageBase<TViewModel> : ContentPage, IDisposable
        where TViewModel : PageViewModelBase
    {
        protected TViewModel ViewModel;

        protected abstract void RegisterViewModel();

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            ViewModel.Unregister();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = ViewModel;
            await ViewModel.InitializeAsync();
        }


        #region Idisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            // Clean all resources
            ViewModel?.Dispose();
            this.DisposeVisualElements();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Idisposable
    }
}

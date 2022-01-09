
using System.Collections.Generic;
using System.Threading.Tasks;
using TwentyOne.ViewModels.ViewModelBase;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;

namespace TwentyOne.ViewModels.PageViewModels
{
    public class GameScreenViewModel : PageViewModelBase
    {
        private List<RoundViewModel> _rounds;
        private RoundViewModel _currentRoundViewModel;

        public GameScreenViewModel()
        {
            Rounds = new List<RoundViewModel>();
            CurrentRoundViewModel = new RoundViewModel();
            NextRoundAsyncCommand = new AsyncCommand(NextRoundAsync, allowsMultipleExecutions: false);

        }

        private async Task NextRoundAsync()
        {
            Rounds.Add(CurrentRoundViewModel);
            CurrentRoundViewModel = new RoundViewModel();
        }

        public override Task InitializeAsync()
        {
            MainThread.BeginInvokeOnMainThread(() => DeviceDisplay.KeepScreenOn = true);
            return base.InitializeAsync();

        }

        public IAsyncCommand NextRoundAsyncCommand { get; }

        public IAsyncCommand SecondRollAsyncCommand { get; }

        public RoundViewModel CurrentRoundViewModel
        {
            get => _currentRoundViewModel;
            set => SetProperty(ref _currentRoundViewModel, value);
        }

        public List<RoundViewModel> Rounds  
        {
            get => _rounds;
            set => SetProperty(ref _rounds, value);
        }
    }
}
